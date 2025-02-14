using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProjectPhoto:IEntity
    {
        [Key]
        public int ProjectPhotoId { get; set; } 

        public string? ProjectPhotoUrl { get; set; }

        public int ProjectId { get; set; }
    }
}
