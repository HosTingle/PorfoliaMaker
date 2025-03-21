﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.DTOs;
namespace DataAccess.Abstract
{
    public interface ICertificateDal:IEntityRepository<Certificate>
    {
        bool UpdateCertificates(CertificatesDto certificatesDto); 
    }
}
