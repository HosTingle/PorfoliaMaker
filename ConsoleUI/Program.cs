﻿// See https://aka.ms/new-console-template for more information
//using Business.Concrete;
//using DataAccess.Concrete.EntityFramework;
//using DataAccess.Concrete.InMemory;
//using Entities.Concrete;

//UsersTest();
////ProjectTest();
//static void UsersTest()
//{
//    Console.WriteLine("Hello, World!");
//    UserManager userManager = new UserManager(new EfUserDal());
//    var result = userManager.GetUsersDetails();
//    if(result.Success==true)
//    {
//        foreach (var users in result.Data)
//        {
//            Console.WriteLine(users.FullName + "--" + users.Title);
//        }
//    }
//    else
//    {
//        Console.WriteLine(result.Message);
//    }

//}

//static void ProjectTest()
//{
//    ProjectManager projectsManager = new ProjectManager(new EfProjectsDal());
//    foreach (var projects in projectsManager.GetAll())
//    {
//        Console.WriteLine(projects.Title);
//    }
//}