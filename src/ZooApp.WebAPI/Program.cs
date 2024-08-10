using Microsoft.EntityFrameworkCore;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Repository;
using ZooApp.WebAPI.Data;
using ZooApp.WebAPI.Data.Contract;
using ZooApp.WebAPI.Infra.UUID;
using ZooApp.WebAPI.Http;
using ZooApp.WebAPI.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Serviços de aplicaçao
IConfiguration configuration = builder.Configuration;

var jsonFilePath = "Infra/animals.json";
builder.Services.AddSingleton(provider => {
    return jsonFilePath;
});

builder.Services.AddDbContext<ZooContext>(options => {
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(connectionString);
});

// Adicionar serviço CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

// Serviços de escopo
builder.Services.AddScoped<IUUIDGererator, UUIDGenerator>();
builder.Services.AddScoped<IAnimalFileRepository, AnimalFileRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IZooRepository, ZooRepository>();

builder.Services.AddControllers(options => {
    options.Filters.Add<HttpResponseExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();