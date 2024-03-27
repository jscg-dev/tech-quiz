using App.Application.Services;
using App.Domain.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .Services
    .AddControllers()
    .AddJsonOptions(_ =>
    {
        _.JsonSerializerOptions.WriteIndented = true;
        _.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        _.JsonSerializerOptions.MaxDepth = 0;
        _.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingDefault;
    });
builder.Services.AddRouting(_ =>
{
    _.LowercaseUrls = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(_ =>
{
    _.AddSecurityDefinition(
        JwtBearerDefaults.AuthenticationScheme,
        new()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT"
        }
    );

    _.AddSecurityRequirement(
        new()
        {
            {
                new()
                {
                    Reference = new()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    },
                    Name = JwtBearerDefaults.AuthenticationScheme,
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        }
    );
});
// db connection configuring
builder.Services.AddDbContext<UContext>(__ =>
{
    __.UseSqlServer(builder.Configuration.GetConnectionString("db"), _sql =>
    {
        _sql.MigrationsHistoryTable("migrations");
        _sql.CommandTimeout(60);
        _sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
    });
});
// security
builder.Services
    .AddAuthentication(_ =>
    {
        _.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        _.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        _.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, _ =>
    {
        _.TokenValidationParameters = new()
        {
            ValidAudience = builder.Configuration.GetSection("AppSettings:jwt:ValidAudience").Value!,
            ValidIssuer = builder.Configuration.GetSection("AppSettings:jwt:ValidIssuer").Value!,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:jwt:IssuerSigningKey").Value!)),
            RequireSignedTokens = true,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization(_ =>
{
    _.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
builder.Services.AddHttpContextAccessor();
// registring services
builder.Services.AddScoped<AsignmentsService>();
builder.Services.AddScoped<CoursesService>();
builder.Services.AddScoped<GroupsService>();
builder.Services.AddScoped<MarksService>();
builder.Services.AddScoped<StudentsService>();

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
