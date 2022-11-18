using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoList.BLL.Interfaces;
using TodoList.BLL.Models;
using TodoList.BLL.Services;
using TodoList.DAL;
using TodoList.DAL.Entity;
using TodoList.DAL.Interfaces;
using TodoList.DAL.Repository;
using TodoList.PL.Extentions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
   .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Goals")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMapper();
builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IGoalService, GoalService>();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
