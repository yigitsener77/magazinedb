using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Services;
using Site.Models;

namespace Site.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly IMagazineService service = new MagazineService();
        protected ArticlesViewModel _model;
        protected void Page_Load(object sender, EventArgs e)
        {
            //GET Protokolü ile veri çekilmek isteniyorsa. Form submit yapısı değilse.
            if(!IsPostBack)
            {
                _model = new ArticlesViewModel
                {
                    Articles = service.GetArticles(),
                    Categories = service.GetCategories()
                };

                rptCategories.DataSource = _model.Categories;
                rptCategories.DataBind();

                rptArticles.DataSource = _model.Articles;
                rptArticles.DataBind();
            }
        }
    }
}