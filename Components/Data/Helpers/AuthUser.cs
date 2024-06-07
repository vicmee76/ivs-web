using ivs_ui.Domain.Models.Dtos.Accounts;
using Microsoft.AspNetCore.Components.Authorization;

namespace ivs_ui.Components.Data.Helpers
{
    public class AuthUser
    {
        public AuthUser()
        {
           
        }

        public async Task<UserAuthDto> GetAuthUserAsync(AuthenticationState state)
        {
            var claims = state.User.Claims.ToList();
            var fullname = claims[2].Value;
           
            var sentenceCase = GeneralClass.ToSentenceCase(fullname);
            var split = sentenceCase.Split(' ');

            var userAuth = new UserAuthDto()
            {
                Id = claims[0].Value,
                Fullname = fullname,
                Email = claims[1].Value,
                Role = claims[3].Value,
                FirstName = split[0].ToString(),
                SentenceCaseFullName = sentenceCase,
            };

            return userAuth;
        }
    }
}
