using Microsoft.EntityFrameworkCore;
using MovieManagement.Api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieManagementApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieManagementApiContext") ?? throw new InvalidOperationException("Connection string 'MovieManagementApiContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();

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

app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyHeader();
    x.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
