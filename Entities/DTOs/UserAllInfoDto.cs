using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserAllInfoDto 
    {
        public string Name { get; set; }

        public List<Skill> Skills { get; set; }

        public List<Certificate> Certificates { get; set; }

        public List<SocialLink> socialLinks { get; set; }

        public List<Project> Projects { get; set; }

        public List<Blog> Blogs { get; set; }

        public List<Comment> Comments { get; set; } 
    }
}
