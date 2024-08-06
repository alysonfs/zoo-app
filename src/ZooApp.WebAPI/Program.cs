using Microsoft.EntityFrameworkCore;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Repository;
using ZooApp.WebAPI.Data;
using ZooApp.WebAPI.Data.Contract;
using ZooApp.WebAPI.Infra.UUID;
using ZooApp.WebAPI.Http;

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

// Serviços de escopo
builder.Services.AddScoped<IUUIDGererator, UUIDGenerator>();
builder.Services.AddScoped<IAnimalFileRepository, AnimalFileRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();