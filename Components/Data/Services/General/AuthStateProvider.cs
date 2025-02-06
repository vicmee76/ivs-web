using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.Accounts;

namespace ivs_ui.Components.Data.Services.General
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IAccountService _accountService;
        private readonly HttpClient _http;
        private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        public AuthStateProvider(HttpClient http, ILocalStorageService localStorageService, IAccountService accountService)
        {
            _localStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
            _accountService = accountService;
            _http = http;
        }
       

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? token = string.Empty;
            var hasKey = await _localStorageService.ContainKeyAsync(Tokens.TokenName)!;
            if (hasKey)
            {
                token = await _localStorageService.GetItemAsync<string>(Tokens.TokenName);
            }
            else
            {
                return new AuthenticationState(_anonymous);
            }

            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;

            // log out when token expires
            if (!string.IsNullOrEmpty(token))
                identity = new ClaimsIdentity(ParseClaimsFromJwt(token), Tokens.JwtName);

            var expiryTime = identity.Claims.Where(x => x.Type == "exp").FirstOrDefault();
            var userId = identity.Claims.FirstOrDefault(x => x.Type == "userid")?.Value.ToString();
            var refresherToken = identity.Claims.FirstOrDefault(x => x.Type == "r")?.Value.ToString();
            var expDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expiryTime.Value)).UtcDateTime;

            if (DateTime.UtcNow > expDate)
            {
                await _localStorageService.ClearAsync();
                identity = await ReLogin(userId, refresherToken);
            }

            _anonymous = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(_anonymous);

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }


       


        public static IEnumerable<Claim> ParseClaimsFromJwt(string? jwt)
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


        private async Task<ClaimsIdentity> ReLogin(string userId, string refreshToken)
        {
            var identity = new ClaimsIdentity();
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(refreshToken))
                return identity;

            var res = await _accountService.ReLogin(userId, refreshToken);
            if (res.result.code != ResponseCodes.ResponseCodeOk)
                return identity;
            
            identity = new ClaimsIdentity(ParseClaimsFromJwt(res.result.token), Tokens.JwtName);
            await _localStorageService.SetItemAsync(Tokens.TokenName, res.result.token);
            await _localStorageService.SetItemAsync(Tokens.RefreshTokenName, res.result.refreshToken);
            return identity;
        }
    }
}
