using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using GrayMe.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GrayMe API",
        Version = "v1",
        Description = "API para cadastro de crianças (sem banco, em memória)."
    });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GrayMeContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GrayMe API v1");
        c.DocumentTitle = "GrayMe API - Swagger";
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();