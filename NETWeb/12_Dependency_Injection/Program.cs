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
             NET Core Dependency Injectionda servislerin ömrünü  (lifecycle) belirtmek için
             üç ana yöntem kullanýlýr.
             AddSingelton,AddScoped,AddTransient. Her birinin avantajlarý ve dezavantajlarý vardýr.
             
             1. AddTransient: Bu yöntem her istek için yeni bir nesne oluþturur. Bu servis her kullanýldýðýnda yeni bir örneðin(instance) oluþturulacaðý anlamýna gelir. Performans açýsýndan maliyetli olabilir çünkü her istekte farklý nesne oluþturulur.
             2. AddScoped: Her Http isteði (request) baþýna bir nesne oluþturulur. Ayný istek içinde ayný nesne kullanýlýr. Ancak farklý isteklerde farklý nesneler oluþur. Ýstekler arasý veri paylaþýmý yapýlmaz.Bu sebeple bazý durumlarda da verimsiz olabilir.
             3. AddSingelton: Uygulama baþladýðýnda bir kez oluþturulan ve uygulama yaþam döngüsü boyunca ayný kalan tek bir nesne oluþturulur. Performans açýsýndan en verimlisidir. Çünkü nesne bir defa oluþturulur.
             
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
