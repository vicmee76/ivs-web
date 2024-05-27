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
    }
}
