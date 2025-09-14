using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _15_Filter_Operations.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        // Oluşan hataları yakalar ve ilgili 404 sayfasına yönlendirir.
        public void OnException(ExceptionContext context)
        {
            context.Result = new RedirectToActionResult("Page404", "Home", null);
        }
    }
}
