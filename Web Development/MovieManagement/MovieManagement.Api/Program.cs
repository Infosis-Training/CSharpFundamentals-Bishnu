using Microsoft.EntityFrameworkCore;
using MovieManagement.Api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieManagementApiContext>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyHeader();
    x.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
