using System.Linq;
using course.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace course.api.Filters
{
    public class ValidationModalStateCustomized : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context){
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ValidateViewModelOutput(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            }
        }

    }
}