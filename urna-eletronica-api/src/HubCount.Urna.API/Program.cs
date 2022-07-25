using HubCount.Urna.Core.AutoMapper;
using HubCount.Urna.Core.Containers;
using HubCount.Urna.Core.Repositories.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var strCon = builder.Configuration.GetConnectionString("DB_HUBCOUNT");
builder.Services.AddDbContext<MySqlContext>(opt =>
    opt.UseMySql(strCon, ServerVersion.AutoDetect(strCon)));

DependecyInjection.RegisterService(builder.Services);
builder.Services.AddAutoMapper(typeof(DTOToEntityMapping), typeof(EntityToDTOMapping));

builder.Services.AddControllers();
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

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();