using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _14_Middleware.Middlewares
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
             // zaman ölçümü başlat
            var watch = Stopwatch.StartNew();

            await _next(context);

            watch.Stop(); // zaman ölçümünü durdurur.

            var elapsed = watch.ElapsedMilliseconds; // Geçen süreyi al

            // Geçen süreyi yazdır.
            Debug.WriteLine($"İstek yolu: {context.Request.Path} -- İşlem Süresi {elapsed} ms");
        }
    }
}
