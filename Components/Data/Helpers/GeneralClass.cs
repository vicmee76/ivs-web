using System.Globalization;
using System.Text.RegularExpressions;

namespace ivs_ui.Components.Data.Helpers
{
    public static class GeneralClass
    {

        public static string ToSentenceCase(string input)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }
        
        public static string MaskNumber(string number)
        {
            if (number.Length <= 4)
                return number; // If the number is too short, just return it as-is.

            var lengthToMask = number.Length - 4;
            var maskedPart = new string('*', lengthToMask);
            var visiblePart = number.Substring(lengthToMask);
            return maskedPart + visiblePart;
        }
    }
}
