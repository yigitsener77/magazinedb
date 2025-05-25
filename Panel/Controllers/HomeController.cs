using BLL.DTOs.Panel;
using BLL.Services;
using BLL.Utilities.Helpers;
using Panel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Panel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorService service = new AuthorService();
        // GET: Aksiyonlar için özellikle belirtilmezse hepsi bu protokolü kullanır.
        public ActionResult Index()
        {
            var articles = service.GetArticles();
            var model = new HomeIndexViewModel();
            model.PublishedArticlesCount = articles.Count(x => !x.Draft);
            model.DraftArticlesCount = articles.Count(x => x.Draft);
            return View(model);
        }

        public ActionResult ArticleList(int page = 1)
        {
            return View(new Pagination<ArticleListDTO>(service.GetArticles(), page, 10));
        }

        public ActionResult CategoryList(int page = 1)
        {
            var model = new CategoriesViewModel();
            model.CategoryPages = new Pagination<CategoryListDTO>(service.GetCategories(), page, 10);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryList(CategoriesViewModel model, int page = 1)
        {
            //model.Categories = service.GetCategories();
            model.CategoryPages = new Pagination<CategoryListDTO>(service.GetCategories(), page, 10);
            if (!ModelState.IsValid) return View(model);

            if (model.Id == null)
            {
                service.CreateCategory(model.Name);
            }
            else
            {
                service.UpdateCategory((int)model.Id, model.Name);
            }
            return RedirectToAction("CategoryList");
        }

        public ActionResult Detail(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        /*
        [HttpPost] public void Activate(int id) => service.ActivateArticle(id);
        [HttpPost] public void Deactivate(int id) => service.DeactivateArticle(id);
        [HttpPost] public void Delete(int id) => service.DeleteArticle(id);
        [HttpPost] public void Recycle(int id) => service.RecycleArticle(id);
        [HttpPost] public DateTime? Publish(int id) => service.PublishArticle(id);
        [HttpPost] public void Unpublish(int id) => service.UnpublishArticle(id);
        */

        [HttpPost] public bool ToggleActivation(int id) => service.ToggleActivationArticle(id);
        [HttpPost] public bool ToggleRecycling(int id) => service.ToggleRecyclingArticle(id);
        [HttpPost] public DateTime? TogglePublishing(int id) => service.TogglePublishingArticle(id);

        [HttpPost] public bool ToggleCategoryActivation(int id) => service.ToggleActivationCategory(id);
        [HttpPost] public bool ToggleCategoryRecycling(int id) => service.ToggleRecyclingCategory(id);

        /*
        // home/topla?a=3&b=12
        public double Topla(double a, double b)
        {
            return a + b;
        }

        // home/hello
        public string Hello()
        {
            return "Hello World!!!";
        }
        */
    }
}