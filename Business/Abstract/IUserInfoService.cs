﻿using Core.Entities.Concrete;
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

        IResult Add(UserInfo userInfo); 

        IResult Update(UserInfo userInfo);

        IResult Delete(UserInfo userInfo); 

        IDataResult<UserInfo> GetById(int id);

        IResult UpdateUserInfoApplication(UserInfoApplicantDto userInfoApplicantDto);

        IResult UpdateUserInfoPersonal(UserInfoPersonalDto userInfoPersonalDto);

        IResult UpdateUserInfoAbout(UserInfoAboutDto userInfoAboutDto);
    }
}
