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
    var result = userManager.GetUsersDetails();
    if(result.Success==true)
    {
        foreach (var users in result.Data)
        {
            Console.WriteLine(users.FullName + "--" + users.Title);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
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