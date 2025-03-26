using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
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
    public class EfUserInfoDal : EfEntityRepositoryBase<UserInfo, PortfContext>, IUserInfoDal  
    {
        public UserInfo AddGetInfo(UserInfo userInfo) 
        {
            using (PortfContext context = new PortfContext())
            {
                context.UserInfo.Add(userInfo);
                context.SaveChanges(); 
                return userInfo;
            }
  
        }
        public bool UpdateUserInfoApplication(UserInfoApplicantDto userInfoApplicantDto)
        {
            using (PortfContext context = new PortfContext())
            {
                var userInfo = context.UserInfo.FirstOrDefault(u => u.UserInfoId == userInfoApplicantDto.UserInfoId);

                if (userInfo == null)
                {
                    return false;
                }

                userInfo.LivingLocation = userInfoApplicantDto.LivingLocation;
                userInfo.Nationality = userInfoApplicantDto.Nationality;
                userInfo.NationalityId = userInfoApplicantDto.NationalityId;
                userInfo.Phone = userInfoApplicantDto.Phone;

                context.SaveChanges();
                return true;
            }
        }
        public bool UpdateUserInfoPersonal(UserInfoPersonalDto userInfoPersonalDto) 
        {
            using (PortfContext context = new PortfContext())
            {
                var userInfo = context.UserInfo.FirstOrDefault(u => u.UserInfoId == userInfoPersonalDto.UserInfoId);

                if (userInfo == null)
                {
                    return false;
                }

                userInfo.MilitaryServiceInfo = userInfoPersonalDto.MilitaryServiceInfo;
                userInfo.Gender = userInfoPersonalDto.Gender;
                userInfo.DisabilityStatus = userInfoPersonalDto.DisabilityStatus;
                userInfo.BirthDate = userInfoPersonalDto.BirthDate;
                userInfo.Smoke = userInfoPersonalDto.Smoke;
                userInfo.Birthplace = userInfoPersonalDto.Birthplace;
                context.SaveChanges();
                return true;
            }

        }
        public bool UpdateUserInfoAbout(UserInfoAboutDto userInfoAboutDto) 
        {
            using (PortfContext context = new PortfContext())
            {
                var userInfo = context.UserInfo.FirstOrDefault(u => u.UserInfoId == userInfoAboutDto.UserInfoId);

                if (userInfo == null)
                {
                    return false;
                }
                userInfo.Profession=userInfoAboutDto.Profession;
                userInfo.FullName=userInfoAboutDto.FullName;
                userInfo.SalaryException = userInfoAboutDto.SalaryException;
                userInfo.Bio = userInfoAboutDto.Bio;
                context.SaveChanges();
                return true;
            }

        }
        public List<UserSearchResultDto> SearchByNickname(string nickname)
        {
            using (PortfContext context = new PortfContext())
            {
                if (string.IsNullOrEmpty(nickname) || nickname.Length < 2)
                {
                    return new List<UserSearchResultDto>();
                }

                var results = context.UserInfo
                    .Where(ui => ui.NickName != null && ui.NickName.ToLower().Contains(nickname.ToLower()))
                    .Join(context.Users, // Join işlemi yap
                        ui => ui.UserInfoId, // UserInfoId üzerinden eşleşme yap
                        u => u.UserInfoId,
                        (ui, u) => new UserSearchResultDto
                        {
                            UserInfoId = ui.UserInfoId,
                            NickName = ui.NickName,
                            UserId = u.UserId
                        })
                    .Take(10)
                    .ToList();

                return results;
            }
        }
        public int? GetUserIdByDetails(int userinfoId)
        {
            using (PortfContext context = new PortfContext())
            {
                var userId = context.Users
                    .Where(u => u.UserInfoId == userinfoId)
                    .Select(u => u.UserId) 
                    .FirstOrDefault();

                return userId == 0 ? null : userId;
            }
        }


    }
}
