using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IUserDal, EfUserDal>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();
//builder.Services.AddSingleton<IProjectsDal, EfProjectsDal>();

//// Register the Business layer dependencies
//builder.Services.AddSingleton<IUserService, UserManager>();
//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProjectService, ProjectManager>();
builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory())
                        .ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacBusinessModule()); });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
