using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserById:IDto
    {
        public int UserId { get; set; }

        public string Username { get; set; } 

        public string Email { get; set; }

        public string ProfilePhoto { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Status { get; set; }

        public int? UserInfoId {  get; set; }
    }
}
