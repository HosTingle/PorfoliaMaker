﻿
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Blogs : IEntity
    {
        public int BlogId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Conte { get; set; }

        public DateTime PublishedAt { get; set; } 
    }
}
