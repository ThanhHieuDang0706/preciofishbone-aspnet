using Microsoft.EntityFrameworkCore;
using PrecioFishboneVietnamASP.NETTraining.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ItemContext>
    (dbContextOptions => dbContextOptions.UseSqlServer(
        builder.Configuration["ConnectionStrings:ASPTrainingDBConnectionString"]));

Console.WriteLine(builder.Configuration["ConnectionStrings:ASPTrainingDBConnectionString"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
