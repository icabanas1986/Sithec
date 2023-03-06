using AutoMapper;
using Sithec.Data.Interface;
using Sithec.Data.Services;
using Sithec.Interfaces;
using Sithec.Data.Context;
using Microsoft.EntityFrameworkCore;
using Sithec;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISithec,Sithec.Services.Sithec>();
builder.Services.AddScoped<IDataServices,DataServices>();
//builder.Services.AddAutoMapper();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataBaseContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddAutoMapper(typeof(MapperProfile));


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
