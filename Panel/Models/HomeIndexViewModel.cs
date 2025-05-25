using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Panel.Models
{
    public class HomeIndexViewModel
    {
        public int PublishedArticlesCount { get; set; } = 0;
        public int DraftArticlesCount { get; set; } = 0;
        public int CategoryCount { get; set; } = 0;
        public int TagCount { get; set; } = 0;
    }
}