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
                var existingSkills = context.Skills
                    .Where(s => s.UserId == userInfoAboutDto.UserId)
                    .ToList();

                if (!existingSkills.Any())
                {
                    return false;
                }

                var existingSkillIds = existingSkills.Select(s => s.SkillId).ToHashSet();
                var incomingSkillIds = userInfoAboutDto.Skills.Select(s => s.SkillId).ToHashSet();

                context.Skills.RemoveRange(
                    existingSkills.Where(s => !incomingSkillIds.Contains(s.SkillId))
                );

                foreach (var existingSkill in existingSkills)
                {
                    var updatedSkill = userInfoAboutDto.Skills
                        .FirstOrDefault(s => s.SkillId == existingSkill.SkillId);

                    if (updatedSkill != null)
                    {
                        existingSkill.Name = updatedSkill.Name;
                        existingSkill.Proficiency = updatedSkill.Proficiency;
                        context.Entry(existingSkill).State = EntityState.Modified;
                    }
                }

              
                var newSkills = userInfoAboutDto.Skills
                    .Where(skill => !existingSkillIds.Contains(skill.SkillId))
                    .Select(skill => new Skill
                    {
                        UserId = userInfoAboutDto.UserId,
                        Name = skill.Name,
                        Proficiency = skill.Proficiency
                    })
                    .ToList();

                if (newSkills.Any())
                {
                    context.Skills.AddRange(newSkills);
                }

                context.SaveChanges();

                return true;
            }
        }



    }
}
