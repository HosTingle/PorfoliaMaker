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

        IResult Add(Blog blog); 
        
        IResult Update(Blog blog);

        IResult Delete(int id);

        IDataResult<Blog> GetById(int id);
    }
}
