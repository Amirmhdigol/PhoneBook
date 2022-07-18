using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhoneBook.Config;
using PhoneBook.Infrastructre.Persistent.EF;
using PhoneBook.RazorPage.Utils;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("DefaulConnection");
builder.Services.RegisterDependency(connectionString);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<CustomJwtValidation>();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SignInKey"])),
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true
    };
    option.SaveToken = true;
    option.Events = new JwtBearerEvents()
    {
        OnTokenValidated = async context =>
        {
            var customValidate = context.HttpContext.RequestServices.GetRequiredService<CustomJwtValidation>();
            await customValidate.Validate(context);
        }
    };
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["token"]?.ToString();
    if (string.IsNullOrWhiteSpace(token) == false)
    {
        context.Request.Headers.Append("Authorization", $"Bearer {token}");
    }
    await next();
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();