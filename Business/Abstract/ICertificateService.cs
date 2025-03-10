using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICertificateService
    {
        IDataResult<List<Certificate>> GetAll(); 

        IResult Add(Certificate certificate); 

        IResult Update(Certificate certificate);

        IResult Delete(Certificate certificate);

        IDataResult<Certificate> GetById(int id);

        IDataResult<List<Certificate>> GetByUserId(int id);

        IResult UpdateCertificate(CertificatesDto certificatesDto); 
    }
}
