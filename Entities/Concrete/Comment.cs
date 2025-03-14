﻿
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        [Key] 
        public int CommentId { get; set; } 

        public int UserId { get; set; }

        public int BlogId { get; set; } 

        public int ProjectId { get; set; }

        public string Conte { get; set; } 

        public DateTime CommentedAt { get; set; }
    }
}
