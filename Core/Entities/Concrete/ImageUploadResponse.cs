using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class ImageUploadResponse:IEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string DisplayUrl { get; set; }
        public string ThumbUrl { get; set; }
        public string MediumUrl { get; set; }
        public string DeleteUrl { get; set; }
    }

}
