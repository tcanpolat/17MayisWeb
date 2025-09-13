namespace _13_State_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Bellek i�i da��t�lm�� �nbellek servisi ekler. �nbelle�e al�nan ��eler uygulaman�n �al��t��� sunucudaki uygulama �rne�i taraf�ndan depolan�r.
            builder.Services.AddDistributedMemoryCache();

            // Session Yap�land�rma
            builder.Services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum ge�erlilik s�resi
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true; // Cookie'nin temel i�levsellik i�in gereklidir.
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

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
