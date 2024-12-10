using CourseWork.Data;
using CourseWork.Interfaces.Cabinets;
using CourseWork.Repository;
using CourseWork.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ICabinetRepository, CabinetRepository>();
builder.Services.AddScoped<ICabinetService, CabinetService>();

builder.Services.AddDbContext<CourseworkContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

app.Run();
