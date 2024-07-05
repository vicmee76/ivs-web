using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using ivs.Domain.Constants;

namespace ivs_ui.Components.Data.Services.General
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private readonly HttpClient _http;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthStateProvider(HttpClient http, ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService ?? throw new ArgumentNullException(nameof(sessionStorageService));
            _http = http;
        }
       

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = string.Empty;
            var hasKey = await _sessionStorageService.ContainKeyAsync(Tokens.TokenName)!;
            if (hasKey)
            {
                token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
            }
            else
            {
                return new AuthenticationState(_anonymous);
            }

            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
                identity = new ClaimsIdentity(ParseClaimsFromJwt(token), Tokens.JwtName);
            
            _anonymous = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(_anonymous);

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }


       


        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            // var K = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));

            keyValuePairs.TryGetValue("role", out object roles);

            if (roles != null)
            {
                var obj = roles.ToString().Split(':');
                claims.Add(new Claim(ClaimTypes.Role, obj[0].ToString()));
                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;

           // return K;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }


    }
}
