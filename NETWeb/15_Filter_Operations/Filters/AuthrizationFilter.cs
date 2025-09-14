using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _15_Filter_Operations.Filters
{
    public class AuthrizationFilter : IAuthorizationFilter
    {
        // Basit bir kullanıcı login kontrolü yap eğer login olmadıysa login sayffasına yönlendir.
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
