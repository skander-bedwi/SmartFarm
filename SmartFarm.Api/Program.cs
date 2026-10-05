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


// service , interface
// Parcelle

builder.Services.AddScoped<IParcelleRepository, ParcelleRepository>();
builder.Services.AddScoped<ParcelleService>();

// Culture
builder.Services.AddScoped<ICultureRepository, CultureRepository>();
builder.Services.AddScoped<CultureService>();

// Plantation
builder.Services.AddScoped<IPlantationRepository, PlantationRepository>();
builder.Services.AddScoped<PlantationService>();

// MesureCapteur
builder.Services.AddScoped<IMesureCapteurRepository, MesureCapteurRepository>();
builder.Services.AddScoped<MesureCapteurService>();

// Irrigation
builder.Services.AddScoped<IIrrigationRepository, IrrigationRepository>();
builder.Services.AddScoped<IrrigationService>();

// Intervention
builder.Services.AddScoped<IInterventionRepository, InterventionRepository>();
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