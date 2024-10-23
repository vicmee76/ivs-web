
using ivs.Domain.Models.Dtos.Accounts;
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
            var fullname = claims[3].Value;
           
            var sentenceCase = GeneralClass.ToSentenceCase(fullname);
            var split = sentenceCase.Split(' ');

            var userAuth = new UserAuthDto()
            {
                Id = claims[1].Value,
                Fullname = fullname,
                Email = claims[2].Value,
                Role = claims[4].Value,
                FirstName = split[0].ToString(),
                SentenceCaseFullName = sentenceCase,
                NameInitials = GetInitials(fullname),
            };

            return userAuth;
        }


        private static string GetInitials(string fullName)
        {
            // Check if the full name is empty
            if (string.IsNullOrWhiteSpace(fullName))
                return "IVS"; // Return IVS for empty names

            // Split the name by spaces and remove empty entries
            string[] nameParts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // If there's only one part, return just its first character
            if (nameParts.Length < 2)
                return nameParts[0].Substring(0, 1).ToUpper();

            // Get the first letter of the first and last names
            char firstInitial = char.ToUpper(nameParts[0][0]);
            char lastInitial = char.ToUpper(nameParts[nameParts.Length - 1][0]);

            // Return the initials combined
            return $"{firstInitial}{lastInitial}";
        }
    }
}
