using BecasEscuela.Data;
using BecasEscuela.Repositories.Class;
using BecasEscuela.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<dbConnection>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("db"));
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IBecasRepository, BecaRepository>();
builder.Services.AddScoped<IAlumnoBecaRepository, AlumnoBecaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:4200", "https://localhost:44406");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
