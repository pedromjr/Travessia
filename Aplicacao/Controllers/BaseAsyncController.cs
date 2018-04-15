using Entities;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication.Controllers
{
    public class BaseAsyncController : BaseAnonymousController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((this.Session == null) || (this.Session["GTUser"] == null))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "SessionExpired", controller = "Home" }));
            else
                base.OnActionExecuting(filterContext);
        }
    }
}