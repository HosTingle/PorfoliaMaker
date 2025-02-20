using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Project:IEntity
    {
        [Key]
        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }
        public string Description{ get; set; }
        public string ProjectUrl{ get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
