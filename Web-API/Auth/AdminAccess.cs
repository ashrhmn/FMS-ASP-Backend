using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Web_API.Auth
{
    public class AdminAccess:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            JwtManage.AuthorizeUser(actionContext,"admin");
            base.OnAuthorization(actionContext);
        }
    }
}