﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Panel
{
    public class CategoryListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArticleCount { get; set; } = 0;
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}
