using DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
var config = builder.Configuration;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.ConfigSqlServerRelationalDatabase(configuration: config);

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
