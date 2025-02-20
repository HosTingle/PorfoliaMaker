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
    public interface IBlogService
    {
        IDataResult<List<Blog>> GetAll();

        IDataResult<List<Blog>> GetAllByUserId(int id); 
        IResult Add(Blog blog); 
        
        IResult Update(Blog blog);

        IResult Delete(Blog blog);

        IDataResult<Blog> GetById(int id);


    }
}
