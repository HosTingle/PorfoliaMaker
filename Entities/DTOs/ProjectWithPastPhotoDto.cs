using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProjectWithPastPhotoDto : IDto 
    {
        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string? ProjectUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ProjectPhotoUrl { get; set; }

        public string PastProjectTitle { get; set; }    
    }
}
