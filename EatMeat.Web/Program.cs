using EatMeat.EntityFramework;
using EatMeat.EntityFramework.Repository;
using EatMeat.Services.AuthenticationServices;
using EatMeat.Services.MeatServices;
using EatMeat.Services.UserServices;
using EatMeat.Services.UserServices.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var services = builder.Services;

services.AddMvc()
    .AddFluentValidation();

string connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/User/SignIn";
        options.LogoutPath = "/Home/Index";
        options.LoginPath = "/Home/Index";
        options.ExpireTimeSpan = TimeSpan.FromDays(3);
    });

services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddTransient<IUserService, UserService>();
services.AddTransient<IAuthenticationService, AuthenticationService>();
services.AddScoped<ICurrentUserService, CurrentUserService>();
services.AddTransient<IMeatService, MeatService>();

services.AddTransient<IValidator<SignInViewModel>, SignInValidator>();
services.AddTransient<IValidator<SignUpViewModel>, SignUpValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
