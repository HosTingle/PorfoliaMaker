using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserInfoPersonalDto:IDto 
    {
        public int UserInfoId { get; set; }

        public int UserId { get; set; } 

        public bool? Smoke { get; set; }

        public string? Gender { get; set; }

        public string? MilitaryServiceInfo { get; set; }

        public string? Birthplace { get; set; }

        public string? DisabilityStatus { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}

