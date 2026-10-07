using Microsoft.EntityFrameworkCore;
using SmartFarm.Application.Interfaces;
using SmartFarm.Application.Services;
using SmartFarm.Infrastructure.Persistence;
using SmartFarm.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// base
builder.Services.AddDbContext<SmartFarmDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Un seul enregistrement générique pour TOUTES les entités
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Les services restent un par un (logique métier propre à chacun)
builder.Services.AddScoped<ParcelleService>();
builder.Services.AddScoped<CultureService>();
builder.Services.AddScoped<PlantationService>();
builder.Services.AddScoped<MesureCapteurService>();
builder.Services.AddScoped<IrrigationService>();
builder.Services.AddScoped<InterventionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();