using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Filters
{
    public class CustomAuthorize : ActionFilterAttribute
    {
        public string Role { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = HttpContext.Current.Session;

            if (session["UserId"] == null)
            {
                filterContext.Result = new RedirectResult("~/Users/Login");
                return;
            }

            if (!string.IsNullOrEmpty(Role))
            {
                string userRole = session["UserRole"] as string;

                if (userRole != Role)
                {
                    filterContext.Result = new RedirectResult("~/Home/Index");
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}