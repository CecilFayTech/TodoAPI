using Microsoft.EntityFrameworkCore;
using TodoAPI.Models.Databases;
using TodoAPI.Repository;
using TodoAPI.Repository.Interfaces;
using TodoAPI.Services;
using TodoAPI.Services.Interfaces;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IToDoServices, ToDoServices>();
builder.Services.AddScoped<ITodoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoCategoryServices, ToDoCategoryServices>();
builder.Services.AddScoped<IToDoCategory, ToDoCategoryRepository>();
builder.Services.AddAutoMapper(typeof(Program));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
