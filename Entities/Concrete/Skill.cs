using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Skill : IEntity
    {
        [Key] 
        public int SkillId { get; set; }  

        public int UserId { get; set; }

        public string Name { get; set; }

        public int Proficiency { get; set; } 
    }
}
