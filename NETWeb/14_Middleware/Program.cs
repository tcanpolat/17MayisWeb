using _14_Middleware.Middlewares;

namespace _14_Middleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Middleware nedir?
            /*
             Middleware .NET Core uygulamalar�nda gelen istekleri (request) i�lemek ve yan�tlar� (response) ol�u�turmak i�in kullan�lan bir yaz�l�m bile�enidir ve ara katman olarak ifade edilir.
            Middleware genel olarak http isteklerinde ve yan�tlar�nda kullan�lman�n yan� s�ra, uygulaman�zda �e�itli i�levleri yerine getirmenizide sa�lar. �ste�i sa�lay�p bir sonraki middleware e ge�i� yapar.
             
             
             */

            app.UseMiddleware<RequestTimingMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
