using CLHBankApp.Models.CLHBankAppContext;
using CLHBankApp.Repository.Implementations;
using CLHBankApp.Repository.Interface;
using CLHBankApp.Service.Implementations;
using CLHBankApp.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CLHBankApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<CLHBankAppContext>();

        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddScoped<IAddressService, AddressService>();
        builder.Services.AddScoped<IAddressRepository, AddressRepository>();

        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();

        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddScoped<IAdminRepository, AdminRepository>();

        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        builder.Services.AddScoped<IAccountRepository, AccountRepository>();

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = "/user/login";
                    config.Cookie.Name = "CLHBANKAPP";
                    config.LogoutPath = "/user/logout";
                });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
    }
}