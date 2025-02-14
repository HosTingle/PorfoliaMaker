using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UsersDetailDto:IDto
    {

        [Key]
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string NickName { get; set; }
        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public string ProfilePhoto { get; set; }

        public string Bio { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }
        public bool Status {  get; set; }

        public int UserInfoId { get; set; }
    }
}
