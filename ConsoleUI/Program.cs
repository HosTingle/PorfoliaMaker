// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

UsersTest();
//ProjectTest();
static void UsersTest()
{
    Console.WriteLine("Hello, World!");
    UsersManager userManager = new UsersManager(new EfUsersDal());

    foreach (var users in userManager.GetUsersDetails())
    {
        Console.WriteLine(users.FullName+ "--" + users.Title);
    }
}

static void ProjectTest()
{
    ProjectsManager projectsManager = new ProjectsManager(new EfProjectsDal());
    foreach (var projects in projectsManager.GetAll())
    {
        Console.WriteLine(projects.Title);
    }
}