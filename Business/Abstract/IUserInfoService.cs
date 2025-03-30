using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserInfoService
    {
        IDataResult<List<UserInfo>> GetAll();

        IDataResult<UserInfo> Add(UserInfo userInfo);

        IResult Update(UserInfo userInfo);

        IResult Delete(UserInfo userInfo); 

        IDataResult<UserInfo> GetById(int id);

        IResult UpdateUserInfoApplicant(int userId, UserInfoApplicantDto userInfoApplicantDto);

        IResult UpdateUserInfoPersonal(int userId, UserInfoPersonalDto userInfoPersonalDto);

        IDataResult<UserInfoAboutDto> UpdateUserInfoAbout(int userId, UserInfoAboutDto userInfoAboutDto);

        IDataResult<UserInfo> GetByUserId(int id);

        IDataResult<List<UserSearchResultDto>> SearchByNickname(string nickname);

        IDataResult<int?> GetUserIdByDetails(int userInfoId);
    }
}
