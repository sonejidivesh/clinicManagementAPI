using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrescriptionGeneration;
using PrescriptionGeneration.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddAuthentication(authOptions =>
//{
//    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

//}).AddJwtBearer(jwtOptions =>
//{
//    var key = builder.Configuration.GetValue<string>("JwtConfig:Key");
//    var keyByte = Encoding.ASCII.GetBytes(key);
//    jwtOptions.SaveToken = true;
//    jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
//    {
//        IssuerSigningKey = new SymmetricSecurityKey(keyByte),
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidateIssuer= false,
//        ClockSkew=TimeSpan.Zero
    
//    };
//});
//builder.Services.AddSingleton(typeof(IJwtTokenManager),typeof(IJwtTokenManager));
builder.Services.AddDbContext<ClinicDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var policy = "Testpolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policy, builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();

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

app.UseCors(policy);
//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
