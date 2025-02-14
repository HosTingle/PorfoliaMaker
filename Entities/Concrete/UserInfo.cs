using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserInfo:IEntity
    {
        public int UserInfoId { get; set; }

        public string? Nationality {  get; set; }

        public string? Phone {  get; set; }  

        public string? NationalityId { get; set; } 

        public string? LivingLocation { get; set; }

        public bool? Smoke {  get; set; }
         
        public string? Gender {  get; set; }

        public string? MilitaryServiceInfo { get; set; }

        public string? Birthplace {  get; set; }

        public string? DisabilityStatus {  get; set; }  

        public DateTime? BirthDate { get; set; } 

        public string? SalaryException {  get; set; }


    }
}
