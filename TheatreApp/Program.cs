using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheatreApp.Data;
using TheatreApp.Data.Configuration;
using TheatreApp.Data.Models;
using TheatreApp.Data.Repository;
using TheatreApp.Data.Repository.Interfaces;
using TheatreApp.Services.Core;
using TheatreApp.Services.Core.Admin;
using TheatreApp.Services.Core.Admin.Interfaces;
using TheatreApp.Services.Core.Interfaces;

namespace TheatreApp.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<TheatreAppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
                {
                    ConfigureIdentity(options);
                })
                .AddEntityFrameworkStores<TheatreAppDbContext>()
                .AddRoles<IdentityRole<Guid>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>();


            AddRepositories(builder);
            AddServices(builder);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();


            await using (var scope = app.Services.CreateAsyncScope())
            {
                var services = scope.ServiceProvider;

                await IdentitySeeder.SeedRolesAsync(services);
                await IdentitySeeder.SeedUsersAsync(services);
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("Home/Error?statusCode={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPlayService, PlayService>();
            builder.Services.AddScoped<IFavouriteService, FavouriteService>();
            builder.Services.AddScoped<IPerformanceService, PerformanceService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<IUserService, UserService>();
        }

        private static void AddRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPlayRepository, PlayRepository>();
            builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            builder.Services.AddScoped<IPerformanceRepository, PerformanceRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
        }

        private static void ConfigureIdentity(IdentityOptions options)
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = false;

            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredUniqueChars = 0;
        }
    }
}
