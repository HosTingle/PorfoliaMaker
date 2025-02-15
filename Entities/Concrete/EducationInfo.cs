using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EducationInfo:IEntity
    {
        [Key]
        public int EducationInfoId { get; set; }

        public int? GPA {  get; set; }

        public string? GradeSystem { get; set; }

        public string? Grade {  get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public int UserId {  get; set; }

        public string UniversityName {  get; set; }

        public string Department { get; set; } 

    }
}
