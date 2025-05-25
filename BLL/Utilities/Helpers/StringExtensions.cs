using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Utilities.Helpers
{
    //Metin Uzantıları: String veri tiplerine ek özellikler bu statik sınıf içerisinde yazılacaktır.
    public static class StringExtensions
    {
        public static string ToUrl(this string text)
        {
            string url = text.Trim().ToLower();
            url = url.Replace('ş', 's')
                .Replace('ç', 'c')
                .Replace('ö', 'o')
                .Replace('ü', 'u')
                .Replace('ı', 'i')
                .Replace('ğ', 'g');
            url = Regex.Replace(url, @"[^\w\d\s]", "");
            url = Regex.Replace(url, @"\s+", "-");
            return url.Trim('-');
        }
    }
}
