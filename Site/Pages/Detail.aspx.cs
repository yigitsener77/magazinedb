using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.DTOs;
using BLL.Services;

namespace Site.Pages
{
    public partial class Detail : System.Web.UI.Page
    {
        private readonly IMagazineService service = new MagazineService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!int.TryParse(Request.QueryString["id"],out int id))
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                ArticleDetailDTO article = service.GetArticleDetail(id);
                if (article == null)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                title.Text = article.Title;
                content.Text = article.Content;
                tags.Text = string.Join(", ", article.Tags);
            }
        }
    }
}