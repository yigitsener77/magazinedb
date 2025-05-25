using BLL.DTOs.Panel;
using BLL.Utilities.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Panel.Models
{
    public class CategoriesViewModel
    {
        [HiddenInput]
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Category Name", Prompt = "Category Name")]
        public string Name { get; set; }

        //public IEnumerable<CategoryListDTO> Categories { get; set; }
        public Pagination<CategoryListDTO> CategoryPages { get; set; }
    }
}