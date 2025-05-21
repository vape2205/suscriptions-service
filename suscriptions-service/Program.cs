using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using suscriptions_service.Infraestructure.Persistence;
using suscriptions_service.Infraestructure.Persistence.Repositories;
using suscriptions_service.Interfaces.Repositories;
using suscriptions_service.Interfaces.Services;
using suscriptions_service.Security;
using suscriptions_service.Services;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ISuscripcionService, SuscripcionService>();
builder.Services.AddScoped<ISuscripcionRepository, SuscripcionRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));

// JWT
var jwtSettingsConfiguration = builder.Configuration.GetSection("AccessTokenSettings");
builder.Services.Configure<AccessTokenSettings>(jwtSettingsConfiguration);
var jwtSettings = jwtSettingsConfiguration.Get<AccessTokenSettings>();

RSA rsa = RSA.Create();
rsa.ImportRSAPublicKey(
    source: Convert.FromBase64String(jwtSettings.PublicKey),
    bytesRead: out int _
);

var rsaKey = new RsaSecurityKey(rsa);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    if (builder.Environment.IsDevelopment())
        options.RequireHttpsMetadata = false;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        RequireSignedTokens = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = rsaKey,
        ClockSkew = TimeSpan.FromMinutes(0)
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetService<AppDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
