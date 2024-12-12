﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Certificates : IEntity
    {
        public int CertificateId { get; set; }
        public int UserId { get; set; } 
        public string Title { get; set; } 

        public string Insitution { get; set; } 

        public DateTime DateReceived { get; set; } 

        public string CertificateUrl{ get; set; } 
    }
}
