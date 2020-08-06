using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using QuickPicSurvey.API.Data;

namespace QuickPicSurvey.API.Helpers
{
    //public class LogUserActivity : IAsyncActionFilter
    //{

    //    //public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    //{
    //    //    //var resultContext = await next();
    //    //    ////var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
    //    //    //var repo = resultContext.HttpContext.RequestServices.GetService<IRespondentRepository>();
    //    //    ////var user = await repo.GetUser(userId);
    //    //    ////user.LastChangedDate = DateTime.Now;
    //    //    //await repo.SaveAll();

    //    //}
    //}
}
