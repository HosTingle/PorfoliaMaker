using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProjectDto:IDto
    {
        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public List<ProjectPhotoDto> PhotosUrls { get; set; }
    }
}
