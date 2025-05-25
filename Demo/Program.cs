using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Services;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMagazineService service = new MagazineService();

            IEnumerable<ArticleListItemDTO> data = service.GetArticles();
            var item = data.FirstOrDefault();
            Console.WriteLine($"{item.Id}: {item.Title}");
            Console.WriteLine(item.ShortContent);
            Console.WriteLine(item.CoverImagePath);
            Console.WriteLine(item.Url);
            Console.WriteLine($"Yorum Sayısı: {item.CommentCount}");
            Console.WriteLine($"Beğenenler: {item.LikeCount}");
            Console.WriteLine($"Beğenmeyenler: {item.DislikeCount}");
            Console.WriteLine($"Etiketler: {string.Join(", ", item.Tags)}");
            Console.WriteLine($"Kategori: {item.CategoryName}");
        }
    }
}
