using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserInfoAboutDto:IDto
    {
        public int UserInfoId { get; set; }

        public int UserId { get; set; }

        public string? SalaryException { get; set; }

        public string? Bio { get; set; } 

        public List<Skill>? Skills { get; set; } 
    }
}
