using dotenv.net;
using HelloSioux.API.Configurations;
using HelloSioux.API.Data;
using HelloSioux.API.Extensions;
using HelloSioux.API.Installations;
using Microsoft.OpenApi.Models;

// Load environment variables first
DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Configuration["DbSettings:ConnectionString"] = 
    Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") ?? 
    builder.Configuration["DbSettings:ConnectionString"];

builder.Configuration["DbSettings:DatabaseName"] = 
    Environment.GetEnvironmentVariable("DATABASE_NAME") ?? 
    builder.Configuration["DbSettings:DatabaseName"];

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Database
    services.Configure<DbSettings>(configuration.GetSection("DbSettings"));
    services.AddSingleton<DbContext>();
    
    // Register application services
    DependencyInstaller.InstallRepositories(services);
    DependencyInstaller.InstallServices(services);
    
    // API related services
    services.AddDataMappers();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    
    // CORS policy
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", builder => 
            builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
    });
    
    // Swagger documentation
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { 
            Title = "HelloSioux.API", 
            Version = "v1", 
            Description = "Hello Sioux API" 
        });
    });
}

void ConfigureApp(WebApplication app)
{
    // Development-specific middleware
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    // Apply CORS policy
    app.UseCors("AllowAllOrigins");
    
    // API routing
    app.UseAuthorization();
    app.MapControllers();
}

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureApp(app);

app.Run();