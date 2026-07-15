using Microsoft.AspNetCore.Authentication.Cookies;
using Interview_task.Services;
using Microsoft.AspNetCore.Authentication.Google;

namespace Interview_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<Interview_task.Services.CurrencyService>();

            builder.Services
      .AddAuthentication(options =>
      {
          options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
      })
      .AddCookie(options =>
      {
          options.LoginPath = "/Account/Login";
          options.LogoutPath = "/Account/Logout";
      })
      .AddGoogle(options =>
      {
          options.ClientId = builder.Configuration["GoogleAuth:ClientId"]!;
          options.ClientSecret = builder.Configuration["GoogleAuth:ClientSecret"]!;
      });


            var app = builder.Build();
            
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
                pattern: "{controller=Home}/{action=Public}/{id?}");

            app.Run();
        }
    }
}