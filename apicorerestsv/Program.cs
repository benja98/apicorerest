using apicorerestsv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseMySql("Server=localhost;Database=ABMComentarios;Uid=root;Pwd=123456", ServerVersion.Create(new Version(1, 0, 0), ServerType.MySql));
});


var app = builder.Build();
app.UseCors(Options =>
{
    Options.WithOrigins("http://localhost:4200");
    Options.AllowAnyMethod();
    Options.AllowAnyHeader();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
