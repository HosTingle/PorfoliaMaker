using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public IResult Add(Blog blog)
        {
            _blogDal.Add(blog);
            return new SuccessResult(Messages.BlogAdd);
        }

        public IResult Delete(Blog blog)
        {
            _blogDal.Delete(blog);
            return new SuccessResult();
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll());
        }

        public IDataResult<Blog> GetById(int id)
        {
            return new SuccessDataResult<Blog>(_blogDal.Get(b=>b.BlogId==id)); 
        }

        public IResult Update(Blog blog)
        {
            _blogDal.Update(blog);
            return new SuccessResult();
        }
    }
}
