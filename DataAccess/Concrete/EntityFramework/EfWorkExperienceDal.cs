using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfWorkExperienceDal : EfEntityRepositoryBase<WorkExperience, PortfContext>, IWorkExperienceDal
    {
        public bool UpdateWorkExperience(WorkExperienceDto workExperienceDto)
        {
            using (PortfContext context = new PortfContext())
            {
                var existingWorkExperiences = context.WorkExperience
                    .Where(s => s.UserId == workExperienceDto.UserId)
                    .ToList();


                var existingWorkExperienceIds = existingWorkExperiences.Select(s => s.WorkExperienceId).ToHashSet();
                var incomingExperienceIds = workExperienceDto.WorkExperience.Select(s => s.WorkExperienceId).ToHashSet();

 
                context.WorkExperience.RemoveRange(
                    existingWorkExperiences.Where(s => !incomingExperienceIds.Contains(s.WorkExperienceId))
                );

                
                foreach (var existingExperience in existingWorkExperiences)
                {
                    var updatedExperience = workExperienceDto.WorkExperience
                        .FirstOrDefault(s => s.WorkExperienceId == existingExperience.WorkExperienceId);

                    if (updatedExperience != null)
                    {
                        existingExperience.CompanyName = updatedExperience.CompanyName;
                        existingExperience.FinalDate = updatedExperience.FinalDate;
                        existingExperience.Province = updatedExperience.Province;
                        existingExperience.Role = updatedExperience.Role;
                        existingExperience.ShortWorkDefination = updatedExperience.ShortWorkDefination;
                        existingExperience.StartDate = updatedExperience.StartDate;
                        context.Entry(existingExperience).State = EntityState.Modified;
                    }
                }

                
                var newWorkExperiences = workExperienceDto.WorkExperience
                    .Where(workExperience => !existingWorkExperienceIds.Contains(workExperience.WorkExperienceId))
                    .Select(workExperience => new WorkExperience
                    {
                        UserId = workExperienceDto.UserId,
                        CompanyName = workExperience.CompanyName,
                        FinalDate = workExperience.FinalDate,
                        Province = workExperience.Province,
                        Role = workExperience.Role,
                        ShortWorkDefination = workExperience.ShortWorkDefination,
                        StartDate = workExperience.StartDate
                    })
                    .ToList();

                if (newWorkExperiences.Any())
                {
                    context.WorkExperience.AddRange(newWorkExperiences);
                }

                context.SaveChanges();

                return true;
            }
        }
    }
}
