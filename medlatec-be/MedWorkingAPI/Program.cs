using AutoMapper;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.PostgreSql;
using MediatR;
using MedWorking.Core.Application.ModuleLogin.Commands;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.ConvertDateOnly;
using MedWorking.Core.Common.Extensions;
using MedWorking.Core.Common.Static;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using MedWorking.Core.Startup.MediatRs;
using MedWorkingAPI.Extensions;
using MedWorkingAPI.Services.BackgroundJob;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Text;
using ConfigurationManager = MedWorking.Core.Common.Static.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
    })
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger MedWorking Solution", Version = "v1" } );
    var security = new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      Array.Empty<string>()
                    }
                  };
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Bearer Authentication with JWT Token",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http
    });
    x.AddSecurityRequirement(security);
    x.MapType<TimeOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString(DateTime.Now.ToString("HH:mm:ss"))
    });
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<MedWorkingContext>>();

builder.Services.AddDbContext<MedWorkingContext>
    (options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("MedWorkingContext"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidIssuer = ConfigurationManager.AppSetting[LoginType.JWTValidIssuer],
            ValidAudience = ConfigurationManager.AppSetting[LoginType.JWTValidAudience],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting[LoginType.JWTSecret]))
        };
    });

var connectionString = builder.Configuration.GetConnectionString("MedWorkingContext");



builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.RegisterServices();

//services cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("*") // or AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

builder.Services.AddHangfire(configuration =>
{
    configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(connectionString);
});
builder.Services.AddHangfireServer();

builder.Services.AddSingleton<IBackgroundJobService, BackgroundJobService>();

//Logging
builder.Logging.AddLog4Net("log4net.config");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//==>Authentication
app.UseAuthentication();
//==>Authentication

app.UseCors();

app.UseAuthorization();

app.Services.AddBackgroundJobService();

app.UseHangfireDashboard();

app.ConfigureCustomExceptionHandler();

//==>Swagger
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger MedWorking V1");
});
//==>Swagger


app.MapControllers();

app.Run();
