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
    public class EfEducationInfoDal : EfEntityRepositoryBase<EducationInfo, PortfContext>, IEducationInfoDal
    {
        public bool UpdateEducation(EducationInfoDto educationInfoDto)
        {
            using (PortfContext context = new PortfContext())
            {
                var existingEducationInfo = context.EducationInfo
                    .Where(s => s.UserId == educationInfoDto.UserId)
                    .ToList();

    

                var existingEducationInfoIds = existingEducationInfo.Select(s => s.EducationInfoId).ToHashSet();
                var incomingEducationInfoIds = educationInfoDto.EducationInfos.Select(s => s.EducationInfoId).ToHashSet();

            
                context.EducationInfo.RemoveRange(
                    existingEducationInfo.Where(s => !incomingEducationInfoIds.Contains(s.EducationInfoId))
                );

        
                foreach (var existingEducation in existingEducationInfo)
                {
                    var updatedEducation = educationInfoDto.EducationInfos
                        .FirstOrDefault(s => s.EducationInfoId == existingEducation.EducationInfoId);

                    if (updatedEducation != null)
                    {
                        existingEducation.Department = updatedEducation.Department;
                        existingEducation.FinishDate = updatedEducation.FinishDate;
                        existingEducation.GPA = updatedEducation.GPA;
                        existingEducation.Grade = updatedEducation.Grade;
                        existingEducation.GradeSystem = updatedEducation.GradeSystem;
                        existingEducation.StartDate = updatedEducation.StartDate;
                        existingEducation.UniversityName = updatedEducation.UniversityName;
                        context.Entry(existingEducation).State = EntityState.Modified;
                    }
                }

                
                var newEducationInfos = educationInfoDto.EducationInfos
                    .Where(educationInfo => !existingEducationInfoIds.Contains(educationInfo.EducationInfoId))
                    .Select(educationInfo => new EducationInfo
                    {
                        UserId = educationInfoDto.UserId,
                        Department = educationInfo.Department,
                        FinishDate = educationInfo.FinishDate,
                        GPA = educationInfo.GPA,
                        Grade = educationInfo.Grade,
                        GradeSystem = educationInfo.GradeSystem,
                        StartDate = educationInfo.StartDate,
                        UniversityName = educationInfo.UniversityName
                    })
                    .ToList();

                if (newEducationInfos.Any())
                {
                    context.EducationInfo.AddRange(newEducationInfos);
                }

                context.SaveChanges();

                return true;
            }
        }
    }
}
