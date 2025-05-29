using GuimasBurguerAppWeb.Data;
using GuimasBurguerAppWeb.Services;
using GuimasBurguerAppWeb.Services.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GuimasBurguerAppWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //var connectionString = builder.Configuration.GetConnectionString("HamburguerDbContextConnection") ?? throw new InvalidOperationException("Connection string 'HamburguerDbContextConnection' not found.");;

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddTransient<IHamburguerService, HamburguerService>();
            builder.Services.AddDbContext<HamburguerDbContext>();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => 
                options.SignIn.RequireConfirmedAccount = false
            ).AddEntityFrameworkStores<HamburguerDbContext>();

            builder.Services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;

                // Lockout settings
                options.Lockout.MaxFailedAccessAttempts = 30;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            builder.Services.AddRazorPages(options => {
                options.Conventions.AuthorizeFolder("/Marcas");
                options.Conventions.AuthorizeFolder("/Categorias");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
