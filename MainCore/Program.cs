using Authentication.Interfaces;
using Coverage.Interfaces;
using DataManager;
using DataManager.Services.Authentication;
using DataManager.Services.Coverage;
using DataManager.Services.HealthCard;
using DataManager.Services.HealthcareProvider;
using DataManager.Services.Language;
using DataManager.Services.Notification;
using DataManager.Services.SystemLog;
using DataManager.Services.User;
using HealthCard.Interfaces;
using HealthcareProvider.Interfaces;
using Language.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notification.Interfaces;
using SystemLog.Interfaces;
using User.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITelephoneService, TelephoneService>();

// Authentication
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRightService, RightService>();

// Coverage
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICoverageService, CoverageService>();
builder.Services.AddScoped<IClientLogService, ClientLogService>();

// HealthcareProvider
builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<ICityService, CityService>();

// HealthCard
builder.Services.AddScoped<IHealthCardService, HealthCardService>();

// Language
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<ISettingsService, SettingsService>();
builder.Services.AddScoped<ITextService, TextService>();

// SystemLog
builder.Services.AddScoped<ISystemLogService, SystemLogService>();

// Notification
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// CORS - tillad Frontend at kalde API'en
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7000", "http://localhost:5000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();
