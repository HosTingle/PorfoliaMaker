using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SocialLink : IEntity
    {
        [Key] 
        public int SocialLinkId { get; set; } 

        public int UserId { get; set; }

        public string Platform {  get; set; } 

        public string Url { get; set; }
    }
}
