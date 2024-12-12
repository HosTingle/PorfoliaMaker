// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

Console.WriteLine("Hello, World!");
UsersManager userManager = new UsersManager(new EfUsersDal());

foreach(var users in userManager.GetByUserBetween(0,4)) 
{
    Console.WriteLine(users.FullName); 
}