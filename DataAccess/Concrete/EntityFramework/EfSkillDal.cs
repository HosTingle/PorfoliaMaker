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
    public class EfSkillDal : EfEntityRepositoryBase<Skill, PortfContext>, ISkillDal 
    {
        public bool UpdateSkills(UserInfoAboutDto userInfoAboutDto)
        {
            using (PortfContext context = new PortfContext())
            {
                var userSkills = context.Skills
                                   .Where(s => s.UserId == userInfoAboutDto.UserId) // Kullanıcı ID'ye göre filtreleme
                                   .ToList(); // Liste olarak getir


                if (userSkills == null)
                {
                    return false;
                }

                // Mevcut yeteneklerin SkillId'lerini alıyoruz
                var existingSkillIds = userSkills.Select(s => s.SkillId).ToHashSet();

                // Yeni gelen yeteneklerden sadece veritabanında olmayanları ekleyelim
                var newSkills = userInfoAboutDto.Skills
                    .Where(skill => !existingSkillIds.Contains(skill.SkillId)) // SkillId veritabanında yoksa ekle
                    .Select(skill => new Skill
                    {
                        UserId = userInfoAboutDto.UserId,
                        Name = skill.Name,
                        Proficiency = skill.Proficiency,
                    })
                    .ToList();

                if (newSkills.Any()) // Eğer eklenecek yeni yetenekler varsa
                {
                    context.Skills.AddRange(newSkills);
                    context.SaveChanges();
                }

                return true;
            }
        }

    }
}
