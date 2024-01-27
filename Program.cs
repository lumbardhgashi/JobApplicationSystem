using JobApplicationSystem.Context;
using JobApplicationSystem.Mappings;
using JobApplicationSystem.Repositories;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services;
using JobApplicationSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

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
builder.Services.AddScoped<IJobPostingRepository, JobPostingRepository>();
builder.Services.AddScoped<IJobPostingService, JobPostingService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IReviewApplicationRepository, ReviewApplicationRepository>();
builder.Services.AddScoped<IReviewApplicationService, ReviewApplicationService>();
builder.Services.AddScoped<ISkillSetRepository, SkillSetRepository>();
builder.Services.AddScoped<ISkillSetService, SkillSetService>();
builder.Services.AddScoped<IHrManagerRepository, HrManagerRepository>();
builder.Services.AddScoped<IHrManagerService, HrManagerService>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IApplicationStatusRepository, ApplicationStatusRepository>();
builder.Services.AddScoped<IApplicationStatusService, ApplicationStatusService>();
builder.Services.AddScoped<IEducationHistoryRepository, EducationHistoryRepository>();
builder.Services.AddScoped<IEducationHistoryService, EducationHistoryService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .WithMethods("POST", "GET", "PUT", "DELETE")
            .WithHeaders(HeaderNames.ContentType);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseCors("Policy1");
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();