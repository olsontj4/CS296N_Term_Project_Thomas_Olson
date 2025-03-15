
using System.Text.RegularExpressions;

namespace QuizCreator.Tools
{
    public class ImageValidator
    {
        public bool IsValid(string imageUrl)
        {
            if (imageUrl is null)
            {
                return false;
            }
            List<string> allowedSites = new()
            {
                @"^https:\/\/media\.discordapp\.net\/.+\.(jpg|JPG|png|PNG|gif|GIF)(?!(js|exe)$)([^.]+$)",
                @"^https:\/\/cdn\.discordapp\.com\/.+\.(jpg|JPG|png|PNG|gif|GIF)(?!(js|exe)$)([^.]+$)",
                @"^https:\/\/images-ext-1\.discordapp\.net\/.+(?!(js|exe)$)([^.]+$)"
            };
            foreach (string site in allowedSites)
            {
                if (Regex.IsMatch(imageUrl, site))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
