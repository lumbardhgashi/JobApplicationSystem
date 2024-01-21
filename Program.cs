using JobApplicationSystem.Context;
using JobApplicationSystem.Mappings;
using JobApplicationSystem.Repositories;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services;
using JobApplicationSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ProfileMap));
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<IApplyRepository, ApplyRepository>();
builder.Services.AddScoped<IApplyService, ApplyService>();
builder.Services.AddScoped<ISkillSetRepository, SkillSetRepository>();
builder.Services.AddScoped<ISkillSetService, SkillSetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
