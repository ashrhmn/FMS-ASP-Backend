using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Web_API.Auth
{
    public class ManagerAccess:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            JwtManage.AuthorizeUser(actionContext,"manager");
            base.OnAuthorization(actionContext);
        }
    }
}