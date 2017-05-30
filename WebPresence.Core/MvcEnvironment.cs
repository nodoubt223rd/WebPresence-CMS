using System.Collections.Generic;
using System.Web.Mvc;

using WebPresence.Common.Enumerators;

namespace WebPresence.Core
{
    public class MvcEnvironment
    {
        public static IDictionary<string, object> GetUnobtrusiveValidation(HtmlHelper htmlHelper, string name, ModelMetadata metaData = null)
        {
            return new Dictionary<string, object>(); ;
        }

        public static ValidationType Validation(HtmlHelper htmlHelper)
        {
            if (htmlHelper.ViewContext.ClientValidationEnabled)
            {
                return ValidationType.StandardClient;
            }
            else
            {
                return ValidationType.Server;
            }
        }

        public static ValidationType Validation(ViewContext context)
        {
            if (context.ClientValidationEnabled)
            {
                return ValidationType.StandardClient;
            }
            else
            {
                return ValidationType.Server;
            }
        }

        public static bool UnobtrusiveAjaxOn(HtmlHelper htmlHelper)
        {
            return false;
        }
    }
}
