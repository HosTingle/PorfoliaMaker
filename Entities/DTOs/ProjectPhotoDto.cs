using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProjectPhotoDto:IDto
    {
        public int ProjectPhotoId { get; set; }

        public string ProjectPhotoUrl { get; set; }
    }
}
