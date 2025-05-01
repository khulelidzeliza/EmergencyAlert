using System.Text;
using System.Text.Json.Serialization;
using EmergencyAlert.Data;
using EmergencyAlert.Services.Implementations;
using EmergencyAlert.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation;
using FluentValidation.AspNetCore;
using EmergencyAlert.Validator;
using System.Reflection;
using EmergencyAlert.SMTP;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFluentValidationAutoValidation(); 
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<SMTPService>();
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        ;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "chven",
            ValidAudience = "isini",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                "5d2ac3c352204e449d6a003e528ee3f4981d72151e3fc7ed4485e1297af56fd7" +
                "063b5d0ef5bc61386948e97d1b4fec402a38fe04d1fa418e55930da1b72b33a4" +
                "4327464628834123ac0d069eec7acb130500d64538ca0a6a8d5ecafdfaa20d43" +
                "bdf2c4c8be1a9e8195add8ecf2f8d43e153da285dd708f747e0e9314f6d6a450" +
                "e44ec6940d1bdb78d0b32548a9b62f1badff07e1ec51552860d89689d0ee985e" +
                "9a3cd4743aecb65982edf4b09e4410a9f0ed82badc57d2e05cba47cac2c2d490" +
                "7bb7aa92ace7bf7718e549b658558fe643bc67b1c9975251120e56448268c95e" +
                "1c241fee8d240295f116eeebb5fc9510b31ebb68177a50bd684dab6182b760d4" +
                "03b7f62e9099c3689223fa261bb9657f57ae79c2f5b23456b661fa97d8ddc465" +
                "bd693fb024c9b27665b39b67d3f6270aaa2f63e0f986d2e1ef83a21d4a2d7be1" +
                "846428e078d7fbc6ea87e42a8abe5f1651658e4cda667cc57a4bd7e64c92de9f" +
                "1a40525c9438085bfa87bfd9fd9dfc1545e904d7fefbe083d736f3f9022816cf" +
                "3465817883883375cd50e166e75a6bf286c230591b44bec82a8aba524301b699"
            )),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CitizenOnly", policy => policy.RequireRole("Citzen"));
    options.AddPolicy("VolunteersOnly", policy => policy.RequireRole("Volunteer"));
    options.AddPolicy("EmergencyServiceOnly", policy => policy.RequireRole("EmergencyService"));
    options.AddPolicy("adminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("AlL", policy => policy.RequireRole("Citzen" , "Volunteer", "EmergencyService", "Admin"));
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
