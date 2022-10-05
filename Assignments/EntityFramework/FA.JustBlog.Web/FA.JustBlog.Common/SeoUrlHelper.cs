using System.Text;

namespace FA.JustBlog.Common
{
    public static class SeoUrlHepler
    {
        public static string FrientlyUrl(string title)
        {
            if (title == null) return "";

            const int maxlen = 80;
            int len = title.Length;
            bool prevdash = false;
            var sb = new StringBuilder(len);
            char c;

            for (int i = 0; i < len; i++)
            {
                c = title[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '/' ||
                    c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if (c == '.') sb.Append("dot");
                else if (c == '#') sb.Append("sharp");
                else if ((int)c >= 128)
                {
                    int prevlen = sb.Length;
                    sb.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length) prevdash = false;
                }
                if (i == maxlen) break;
            }

            if (prevdash)
                return sb.ToString().Substring(0, sb.Length - 1);
            else
                return sb.ToString();
        }

        private static string RemapInternationalCharToAscii(char c)
        {
            var s = c.ToString().ToLowerInvariant();

            var mappings = new Dictionary<string, string>
        {
            { "a", "àåáâäãåąảạắặằẳăấầậẩ"},
            { "c", "çćčĉ" },
            { "d", "đ" },
            { "e", "èéêëęẹẻếềệể" },
            { "g", "ğĝ" },
            { "h", "ĥ" },
            { "i", "ìíîïıịỉ" },
            { "j", "ĵ" },
            { "l", "ł" },
            { "n", "ñń" },
            { "o", "òóôõöøőðơớợờỡốồộổọỏ"},
            { "r", "ř" },
            { "s", "śşšŝ" },
            { "ss", "ß" },
            { "th", "Þ" },
            { "u", "ùúûüŭůũủụ" },
            { "y", "ýÿỹỷỵỳ" },
            { "z", "żźž" }
        };

            foreach (var mapping in mappings)
            {
                if (mapping.Value.Contains(s))
                    return mapping.Key;
            }

            return string.Empty;
        }
    }
}