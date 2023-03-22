using System.Text.Json.Serialization;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using PrecioFishboneVietnamASP.NETTraining.DbContexts;
using PrecioFishboneVietnamASP.NETTraining.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ItemContext>
    (dbContextOptions => dbContextOptions.UseSqlServer(
        builder.Configuration["ConnectionStrings:ASPTrainingDBConnectionString"]));

builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

// ! Auth
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin",
        policy => policy.RequireRole("Admin"));
    options.AddPolicy("Member", policy =>
        policy.RequireRole("Admin", "Viewer"));
});


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseFileServer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
