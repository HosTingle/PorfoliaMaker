﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Subscription : IEntity
    {
        [Key]
        public int SubscriptionId { get; set; }

        public string Email { get; set; }   

        public DateTime SubscribedAt { get; set; }   

        public int UserId {  get; set; }
    }
}
