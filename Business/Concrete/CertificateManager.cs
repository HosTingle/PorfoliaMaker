using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CertificateManager : ICertificateService
    {
        ICertificateDal _certificatesDal;

        public CertificateManager(ICertificateDal certificatesDal)
        {
            _certificatesDal = certificatesDal;
        }

        public IResult Add(Certificate certificate)
        {
            _certificatesDal.Add(certificate);
            return new SuccessResult();
        }

        public IResult Delete(Certificate certificate)
        {
            _certificatesDal.Delete(certificate);
            return new SuccessResult();
        }

        public IDataResult<List<Certificate>> GetAll()
        {
            return new SuccessDataResult<List<Certificate>>(_certificatesDal.GetAll());
        }

        public IDataResult<Certificate> GetById(int id)
        {
            return new SuccessDataResult<Certificate>(_certificatesDal.Get(c=>c.CertificateId==id));
        }

        public IDataResult<List<Certificate>> GetByUserId(int id) 
        {
            return new SuccessDataResult<List<Certificate>>(_certificatesDal.GetAll(c=>c.UserId == id));
        }

        public IResult Update(Certificate certificate)
        {
            _certificatesDal.Update(certificate);
            return new SuccessResult();
        }

        public IResult UpdateCertificate(CertificatesDto certificatesDto)
        {
            var result=_certificatesDal.UpdateCertificates(certificatesDto);
            if (result)
            {
                return new SuccessResult(Messages.UpdateCertificate);
            }
            return new ErrorResult(Messages.UpdateCertificateError);


        }
    }
}
