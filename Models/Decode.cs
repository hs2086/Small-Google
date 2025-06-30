namespace BigDataProject.Models
{
    public class Decode
    {
        public string SanitizeUrl(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = "https://" + url;
            }
            // Dictionary for first set of replacements
            var key1 = new Dictionary<string, string>
            {
                { "__BSLASH__", "\\" },
                { "__SLASH__", "/" },
                { "__COLON__", ":" },
                { "__STAR__", "*" },
                { "__QMARK__", "?" },
                { "__QUOTE__", "\"" },
                { "__LT__", "<" },
                { "__GT__", ">" },
                { "__PIPE__", "|" }
            };

            // Perform replacements for key1
            foreach (var kvp in key1)
            {
                url = url.Replace(kvp.Key, kvp.Value);
            }

            // Dictionary for second set of replacements
            var key2 = new Dictionary<string, string>
            {
                { "_BSLASH_", "\\" },
                { "_SLASH_", "/" },
                { "_COLON_", ":" },
                { "_STAR_", "*" },
                { "_QMARK_", "?" },
                { "_QUOTE_", "\"" },
                { "_LT_", "<" },
                { "_GT_", ">" },
                { "_PIPE_", "|" }
            };

            // Perform replacements for key2
            foreach (var kvp in key2)
            {
                url = url.Replace(kvp.Key, kvp.Value);
            }

            return url;
        }


        public string? Hamdy(string url)
        {
            if (url != null)
            {
                string[] UrlPlusFreq = url.Split("|||");
                string UrlWithoutTXT = UrlPlusFreq[0].Substring(0, UrlPlusFreq[0].Length - 4);
                string u = SanitizeUrl(UrlWithoutTXT);
                if (u.EndsWith("xml"))
                {
                    int indexofSlash = u.LastIndexOf('/');
                    u = u.Substring(0, indexofSlash);
                }
                return u;
            }
            return null;
        }

        public string? freq(string url)
        {
            if (url != null)
            {
                string[] UrlPlusFreq = url.Split("|||");
                return UrlPlusFreq[1];
            }
            return null;
        }

    }
}
