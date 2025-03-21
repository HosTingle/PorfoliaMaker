﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();

        IResult Add(Comment comment);

        IResult Update(Comment comment);

        IResult Delete(Comment comment);

        IDataResult<Comment> GetById(int id);
    }
}
