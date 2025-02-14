using Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkExperience:IEntity
    {
        public int WorkExperienceId { get; set; }

        public string Province { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinalDate { get; set; } 

        public string Role {  get; set; }

        public string ShortWorkDefination {  get; set; } 

        public int UserId {  get; set; }
    }
}
