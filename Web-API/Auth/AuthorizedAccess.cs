using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Web_API.Auth
{
    public class AuthorizedAccess:AuthorizationFilterAttribute
    {
        private readonly List<string> _roles;

        public AuthorizedAccess(string role)
        {
            _roles = new List<string>
            {
                role
            };
        }

        public AuthorizedAccess(List<string> roles)
        {
            _roles = roles;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            JwtManage.AuthorizeUser(actionContext,_roles);
            base.OnAuthorization(actionContext);
        }
    }
}