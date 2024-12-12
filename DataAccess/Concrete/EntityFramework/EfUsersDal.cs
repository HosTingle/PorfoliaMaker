using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO.MemoryMappedFiles;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfUsersDal : IUsersDal
    {
        public void Add(Users entity)
        {
            using(PortfContext context= new PortfContext())
            {
                var addedEntity= context.Entry(entity);
                addedEntity.State= EntityState.Added;   
                context.SaveChanges();

            }
        
        }

        public void Delete(Users entity)
        {
            using (PortfContext context = new PortfContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Users Get(Expression<Func<Users, bool>> filter = null)
        {
            using (PortfContext context = new PortfContext())
            {
                return context.Set<Users>().SingleOrDefault(filter);

            }
         
        }

        public List<Users> GetAll(Expression<Func<Users, bool>> filter = null)
        {
            using (PortfContext context = new PortfContext())
            {
                return filter == null ?
                    context.Set<Users>().ToList() :
                    context.Set<Users>().Where(filter).ToList();

            }
        }

        public void Update(Users entity)
        {
            using (PortfContext context = new PortfContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
