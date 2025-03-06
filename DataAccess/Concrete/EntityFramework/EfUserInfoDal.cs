using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserInfoDal : EfEntityRepositoryBase<UserInfo, PortfContext>, IUserInfoDal  
    {

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

                userInfo.SalaryException = userInfoAboutDto.SalaryException;
                userInfo.Bio = userInfoAboutDto.Bio;
                context.SaveChanges();
                return true;
            }

        }
    }
}
