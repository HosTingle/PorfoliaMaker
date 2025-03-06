using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserInfoApplicantDto:IDto
    {
        public int UserInfoId { get; set; }

        public int UserId { get; set; } 

        public string? Nationality { get; set; }

        public string? Phone { get; set; }

        public string? NationalityId { get; set; }

        public string? LivingLocation { get; set; }
    }
}
