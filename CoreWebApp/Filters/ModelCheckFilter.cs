using CoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreWebApp.Filters
{
    public class ModelCheckFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ModelState.IsValid) return;
            context.Result = new BadRequestObjectResult(new ErrorViewModel {
                Message = "Invalid parameters.",
                ModelState = context.ModelState
            });
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }
    }
}
