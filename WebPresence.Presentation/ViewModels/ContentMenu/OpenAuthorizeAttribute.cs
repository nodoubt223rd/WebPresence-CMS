using System.Web.Mvc;
using System.Web.Routing;

namespace WebPresence.Presentation.ViewModels.ContentMenu
{
    public class OpenAuthorizeAttribute : AuthorizeAttribute
    {
        public OpenAuthorizeAttribute(AuthorizeAttribute attribute)
        {
            Order = attribute.Order;
            Roles = attribute.Roles;
            Users = attribute.Users;
        }

        public bool Authorized(RequestContext requestContext)
        {
            return AuthorizeCore(requestContext.HttpContext);
        }
    }

    public static class AuthorizeAttributeExtentions
    {
        public static bool Authorized(this AuthorizeAttribute attribute, ControllerContext context)
        {
            var securityActionFilterAttribute = new OpenAuthorizeAttribute(attribute);

            return securityActionFilterAttribute.Authorized(context.RequestContext);
        }
    }
}
