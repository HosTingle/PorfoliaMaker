using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserAllInfoDto:IDto 
    {
        public string Name { get; set; }

        public string NickName { get; set; } 
        
        public string LinkedIn {  get; set; } 

        public string Github {  get; set; }

        public string Website {  get; set; }

        public string ProfilePhoto {  get; set; }

        public List<Skill> Skills { get; set; }

        public List<Comment> Comments { get; set; } 

        public List<Certificate> Certificates { get; set; }

        public List<SocialLink> SocialLinks { get; set; } 

        public List<ProjectDto> Projects { get; set; }

        public List<Blog> Blogs { get; set; }

        public List<WorkExperience> WorkExperiences { get; set; }

        public UserInfo UserInfo { get; set; }    

        public List<ForeignLanguage> ForeignLanguage { get; set; }

        public List<EducationInfo> EducationInfo { get; set; }   
    }
}
