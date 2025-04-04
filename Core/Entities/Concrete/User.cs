﻿

using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }

        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public string? ProfilePhoto { get; set; }

        public string Username { get; set; } 

        public DateTime CreatedAt { get; set; }

        public bool Status { get; set; }

        public int? UserInfoId { get; set; }

    }
}
