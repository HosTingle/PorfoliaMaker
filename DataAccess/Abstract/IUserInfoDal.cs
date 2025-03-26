using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserInfoDal : IEntityRepository<UserInfo>
    {
        bool UpdateUserInfoApplication(UserInfoApplicantDto userInfoApplicantDto);

        bool UpdateUserInfoPersonal(UserInfoPersonalDto userInfoPersonalDto);

        bool UpdateUserInfoAbout(UserInfoAboutDto userInfoAboutDto);

        UserInfo AddGetInfo(UserInfo userInfo);

        List<UserSearchResultDto> SearchByNickname(string nickname);

        int? GetUserIdByDetails(int userinfoId);
    }
}
