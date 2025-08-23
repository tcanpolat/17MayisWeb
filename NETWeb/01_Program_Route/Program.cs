namespace _01_Program_Route
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Web  uygulamas� i�in bir builder olu�turulur.
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Bu Web projesine MVC yap�s� eklendi.
            builder.Services.AddControllersWithViews();

            // App Build edilir.
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // her http iste�i https e y�nlendirilsin.
            app.UseHttpsRedirection();
            // static dosyalar kullan�labilsin.
            app.UseStaticFiles();

            // Y�nlendirmler kullan�ls�n.
            app.UseRouting();

            // Yetkilendirme olsun.
            app.UseAuthorization();
            
            // Routelar (Rotalar) => Y�nlendirmeler
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
               name: "about",
               pattern: "about",
               defaults: new { controller = "Home", action = "About" });

            app.MapControllerRoute(
              name: "aboutDetails",
              pattern: "about/detail/{id}",
              defaults: new { controller = "Home", action = "AboutDetail" });

            app.Run();
        }
    }
}
