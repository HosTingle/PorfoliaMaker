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
    public class EfForeignLanguageDal:EfEntityRepositoryBase<ForeignLanguage,PortfContext>,IForeignLanguageDal
    {
        public bool UpdateForeignLanguage(ForeignLanguageDto foreignLanguageDto)
        {
            using (PortfContext context = new PortfContext())
            {
                var existingForeignLanguages = context.ForeignLanguage
                    .Where(s => s.UserId == foreignLanguageDto.UserId)
                    .ToList();

                if (!existingForeignLanguages.Any()) 
                {
                    return false;
                }

                var existingForeignLanguageIds = existingForeignLanguages.Select(s => s.ForeignLanguageId).ToHashSet();
                var incomingForeignLanguageIds = foreignLanguageDto.ForeignLanguages.Select(s => s.ForeignLanguageId).ToHashSet();

       
                context.ForeignLanguage.RemoveRange(
                    existingForeignLanguages.Where(s => !incomingForeignLanguageIds.Contains(s.ForeignLanguageId))
                );

            
                foreach (var existingLanguage in existingForeignLanguages)
                {
                    var updatedLanguage = foreignLanguageDto.ForeignLanguages
                        .FirstOrDefault(s => s.ForeignLanguageId == existingLanguage.ForeignLanguageId);

                    if (updatedLanguage != null)
                    {
                        existingLanguage.Language = updatedLanguage.Language;
                        existingLanguage.Rating = updatedLanguage.Rating;
                        existingLanguage.WhereDidYouLearn = updatedLanguage.WhereDidYouLearn;
                        context.Entry(existingLanguage).State = EntityState.Modified; 
                    }
                }

         
                var newForeignLanguages = foreignLanguageDto.ForeignLanguages
                    .Where(foreignLanguage => !existingForeignLanguageIds.Contains(foreignLanguage.ForeignLanguageId))
                    .Select(foreignLanguage => new ForeignLanguage
                    {
                        UserId = foreignLanguageDto.UserId, 
                        Language = foreignLanguage.Language,
                        Rating = foreignLanguage.Rating,
                        WhereDidYouLearn = foreignLanguage.WhereDidYouLearn
                    })
                    .ToList();

                if (newForeignLanguages.Any())
                {
                    context.ForeignLanguage.AddRange(newForeignLanguages);
                }

                context.SaveChanges();

                return true;
            }
        }


    }
}
