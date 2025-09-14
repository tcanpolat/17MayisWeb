using _16_AutoMapper.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace _16_AutoMapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // AutoMapper: .NET Core projelerinde veri transfer nesnelerini (DTO) domain modellerine ve tersi iþlemleri kolayca yapmamýzý saðlayan kütüphanedir.
            // AutoMapper ekledik
            builder.Services.AddAutoMapper(typeof(UserProfile));

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
