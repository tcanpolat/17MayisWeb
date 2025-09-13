using _12_Dependency_Injection.Services.Abstract;
using _12_Dependency_Injection.Services.Concrete;

namespace _12_Dependency_Injection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // LifeCycle
            /* 
             IMyService ve MyService Container'a eklenir.
             NET Core Dependency Injectionda servislerin �mr�n�  (lifecycle) belirtmek i�in
             �� ana y�ntem kullan�l�r.
             AddSingelton,AddScoped,AddTransient. Her birinin avantajlar� ve dezavantajlar� vard�r.
             
             1. AddTransient: Bu y�ntem her istek i�in yeni bir nesne olu�turur. Bu servis her kullan�ld���nda yeni bir �rne�in(instance) olu�turulaca�� anlam�na gelir. Performans a��s�ndan maliyetli olabilir ��nk� her istekte farkl� nesne olu�turulur.
             2. AddScoped: Her Http iste�i (request) ba��na bir nesne olu�turulur. Ayn� istek i�inde ayn� nesne kullan�l�r. Ancak farkl� isteklerde farkl� nesneler olu�ur. �stekler aras� veri payla��m� yap�lmaz.Bu sebeple baz� durumlarda da verimsiz olabilir.
             3. AddSingelton: Uygulama ba�lad���nda bir kez olu�turulan ve uygulama ya�am d�ng�s� boyunca ayn� kalan tek bir nesne olu�turulur. Performans a��s�ndan en verimlisidir. ��nk� nesne bir defa olu�turulur.
             
             */
            builder.Services.AddSingleton<IMyService, MyService>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
