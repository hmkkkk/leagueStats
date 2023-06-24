using API.Middleware;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => 
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseMySql(connectionString,  ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddScoped<IRiotClient, RiotClient>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<ISummonerRepository, SummonerRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
