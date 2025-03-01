using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public IResult AddBlog(BlogDto blogDto) 
        {
            Blog blog = new Blog
            {
                
                Title = blogDto.Title,
                BlogPhoto = blogDto.BlogPhoto,
                Conte = blogDto.Conte,
                PublishedAt = blogDto.PublishedAt,
                UserId = blogDto.UserId
                
            };
            IResult result = Add(blog);

            if (result.Success)
            {
                return new SuccessResult(Messages.BlogAdd);
            }
            return new ErrorResult(Messages.BlogNotAdd);

        }
        public IResult UpdateBlog(BlogDto blogDto) 
        {
            Blog blog = new Blog
            {
                Title = blogDto.Title,
                BlogPhoto = blogDto.BlogPhoto,
                Conte = blogDto.Conte,
                PublishedAt = blogDto.PublishedAt,
                UserId = blogDto.UserId,
                BlogId=blogDto.BlogId
                
            };
            IResult result = Update(blog);

            if (result.Success)
            {
                return new SuccessResult(Messages.BlogAdd);
            }
            return new ErrorResult(Messages.BlogNotAdd);

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
        [SecuredOperation("user")]
        public IDataResult<List<BlogSecureDto>> GetAllByUserId(int id)
        {
            var blogs = _blogDal.GetAll(b => b.UserId == id)
                                .Select(b => new BlogSecureDto
                                {
                                    BlogId = b.BlogId,
                                    Title = b.Title,
                                    Conte = b.Conte,
                                    BlogPhoto = b.BlogPhoto,
                                    PublishedAt = b.PublishedAt
                                }).ToList();

            return new SuccessDataResult<List<BlogSecureDto>>(blogs);
        }

        public IDataResult<Blog> GetById(int id)
        {
            return new SuccessDataResult<Blog>(_blogDal.Get(b=>b.BlogId==id)); 
        }

        public IResult Update(Blog blog)
        {
            
            _blogDal.Update(blog);
            return new SuccessResult(Messages.UpdateBlog);
        }
    }
}
