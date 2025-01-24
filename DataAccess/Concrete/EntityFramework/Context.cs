using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PortfContext:DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DNUIALQ\SQLKOD;initial Catalog=portfolio;integrated Security=true;TrustServerCertificate=True;");
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<Comment> Comments { get; set; } 

        public DbSet<Event> Events { get; set; } 
        public DbSet<Skill> Skills { get; set; } 
        public DbSet<SocialLink> SocialLinks { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<ProjectPhotos> ProjectPhotos { get; set; } 


    }
}
