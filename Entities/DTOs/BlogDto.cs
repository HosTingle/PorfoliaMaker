﻿using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class BlogDto : IDto 
    {
        public int BlogId { get; set; } 
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Conte { get; set; }

        public string BlogPhoto { get; set; }

        public DateTime PublishedAt { get; set; }
    }
}
