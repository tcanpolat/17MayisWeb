using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _15_Filter_Operations.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Action(View) çalıştıktan sonra tetiklenir.
            Debug.WriteLine($"Action Executed. Executed Time: {DateTime.Now}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Action(View) çalıştığı sırada tetiklenir.
            Debug.WriteLine($"Action Executing. Executing Time: {DateTime.Now}");
        }
    }
}
