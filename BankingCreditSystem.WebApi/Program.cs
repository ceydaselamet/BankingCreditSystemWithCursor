using BankingCreditSystem.Application;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Middlewares;
using BankingCreditSystem.Persistence;
using Microsoft.IdentityModel.Tokens;
using BankingCreditSystem.Core.Security.JWT;
using BankingCreditSystem.Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BankingCreditSystem.Core.Security.Encryption;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();


// Add Application Services
builder.Services.AddApplicationServices();

// Add Persistence Services
builder.Services.AddPersistenceServices(builder.Configuration);

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
            ValidAudience = builder.Configuration["TokenOptions:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(builder.Configuration["TokenOptions:SecurityKey"]!)
        };
    });

// Add Authorization Pipeline
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "tr-TR", "en-US" }; 
    options.SetDefaultCulture("tr-TR") 
           .AddSupportedCultures(supportedCultures)
           .AddSupportedUICultures(supportedCultures);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


