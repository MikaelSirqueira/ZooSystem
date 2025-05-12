using Microsoft.EntityFrameworkCore;
using ZooSystem.Infrastructure.DataAcess;
using ZooSystem.Infrastructure.Migrations;
using ZooSystem.UseCases.Animals.Delete;
using ZooSystem.UseCases.Animals.Get;
using ZooSystem.UseCases.Animals.Update;
using ZooSystem.UseCases.Cares.Delete;
using ZooSystem.UseCases.Cares.Get;
using ZooSystem.UseCases.Cares.Register;
using ZooSystem.UseCases.Cares.Update;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ZooSystemDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<RegisterAnimalUseCase>();
builder.Services.AddScoped<GetAnimalsUseCase>();
builder.Services.AddScoped<UpdateAnimalUseCase>();
builder.Services.AddScoped<DeleteAnimalUseCase>();

builder.Services.AddScoped<GetCaresUseCase>();
builder.Services.AddScoped<RegisterCareUseCase>();
builder.Services.AddScoped<UpdateCareUseCase>();
builder.Services.AddScoped<DeleteCareUseCase>();

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

app.UseCors("AllowLocalhost3000");

app.MapControllers();

DatabaseMigration.Migrate(connectionString, app.Services);

app.Run();
