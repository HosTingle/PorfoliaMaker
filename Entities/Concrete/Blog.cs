
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Blog : IEntity
    {
        [Key]
        public int BlogId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Conte { get; set; }

        public string BlogPhoto {  get; set; }

        public DateTime PublishedAt { get; set; } 
    }
}
