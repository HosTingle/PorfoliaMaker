using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Users:IEntity
    {
        [Key]
        public int UserId { get; set; }

        public string FullName { get; set; } 

        public string Email { get; set; }

        public string PasswordSalt { get; set; } 

        public string PasswordHash { get; set; }

        public string ProfilePhoto { get; set; }

        public string Bio { get; set; }

        public DateTime CreatedAt{ get; set; } 
    }
}
