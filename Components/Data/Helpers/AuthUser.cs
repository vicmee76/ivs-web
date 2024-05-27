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

            var userId = claims[0].Value;
            var fullname = claims[2].Value;
            var email = claims[3].Value;
            var sentenceCase = GeneralClass.ToSentenceCase(fullname);

            var userAuth = new UserAuthDto()
            {
                Id = userId,
                Fullname = fullname,
                Email = email,
                SentenceCaseFullName = sentenceCase,
            };

            return userAuth;
        }
    }
}
