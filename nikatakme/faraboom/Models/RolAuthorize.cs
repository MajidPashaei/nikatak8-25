using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace faraboom.Models
{
    /// <summary>
    /// دسترسی مدیر و منشی
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RolAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filter)
        {
            if (filter.HttpContext.User.Identity.Name == "admin")
                base.OnActionExecuting(filter);

            else
                filter.Result = new RedirectResult("/home/index");
        }

    }//


}//
