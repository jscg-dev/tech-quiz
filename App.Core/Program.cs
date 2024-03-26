using App.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .Services
    .AddControllers()
    .AddJsonOptions(_ =>
    {
        _.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        _.JsonSerializerOptions.MaxDepth = 0;
        _.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingDefault;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UContext>(__ =>
{
    __.UseSqlServer(builder.Configuration.GetConnectionString("db"), _sql =>
    {
        _sql.MigrationsHistoryTable("migrations");
        _sql.CommandTimeout(60);
        _sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
    });
});

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
