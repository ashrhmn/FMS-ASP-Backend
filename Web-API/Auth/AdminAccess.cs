using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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