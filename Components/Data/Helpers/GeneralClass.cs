using System.Globalization;
using System.Text.RegularExpressions;

namespace ivs_ui.Components.Data.Helpers
{
    public static class GeneralClass
    {

        public static string ToSentenceCase(string input)
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }
        
        public static string MaskNumber(string number)
        {
            if (number.Length <= 4)
                return number; // If the number is too short, just return it as-is.

            var lengthToMask = number.Length - 4;
            var maskedPart = new string('*', lengthToMask);
            var visiblePart = number[lengthToMask..];
            return maskedPart + visiblePart;
        }
        
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
