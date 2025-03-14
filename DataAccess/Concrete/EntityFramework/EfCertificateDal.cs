using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCertificateDal : EfEntityRepositoryBase<Certificate, PortfContext>, ICertificateDal
    {
        public bool UpdateCertificates(CertificatesDto certificatesDto)
        {
            using (PortfContext context = new PortfContext())
            {
                var existingCertificates = context.Certificates
                    .Where(s => s.UserId == certificatesDto.UserId)
                    .ToList();

        

                var existingCertificateIds = existingCertificates.Select(s => s.CertificateId).ToHashSet();
                var incomingCertificateIds = certificatesDto.Certificates.Select(s => s.CertificateId).ToHashSet();

             
                context.Certificates.RemoveRange(
                    existingCertificates.Where(s => !incomingCertificateIds.Contains(s.CertificateId))
                );

            
                foreach (var existingCertificate in existingCertificates)
                {
                    var updatedCertificate = certificatesDto.Certificates
                        .FirstOrDefault(s => s.CertificateId == existingCertificate.CertificateId);

                    if (updatedCertificate != null)
                    {
                        existingCertificate.CertificateUrl = updatedCertificate.CertificateUrl;
                        existingCertificate.DateReceived = updatedCertificate.DateReceived;
                        existingCertificate.Title = updatedCertificate.Title;
                        existingCertificate.Institution = updatedCertificate.Institution;
                        context.Entry(existingCertificate).State = EntityState.Modified;
                    }
                }

               
                var newCertificates = certificatesDto.Certificates
                    .Where(certificate => !existingCertificateIds.Contains(certificate.CertificateId))
                    .Select(certificate => new Certificate
                    {
                        UserId = certificatesDto.UserId,
                        CertificateUrl = certificate.CertificateUrl,
                        DateReceived = certificate.DateReceived,
                        Title = certificate.Title,
                        Institution = certificate.Institution
                    })
                    .ToList();

                if (newCertificates.Any())
                {
                    context.Certificates.AddRange(newCertificates);
                }

                context.SaveChanges();

                return true;
            }
        }

    }
}
