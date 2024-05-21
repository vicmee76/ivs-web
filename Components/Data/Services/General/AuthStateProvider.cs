using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

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
            await _sessionStorageService.SetItemAsync("AccessToken", string.Empty)!;
            var hasKey = await _sessionStorageService.ContainKeyAsync("AccessToken")!;
            if (hasKey)
            {
                token = await _sessionStorageService.GetItemAsync<string>("AccessToken");

            }
            else
            {
                return new AuthenticationState(_anonymous);
            }

            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            }
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
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
