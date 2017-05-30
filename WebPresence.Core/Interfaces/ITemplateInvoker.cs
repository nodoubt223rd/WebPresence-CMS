using System.Web.Mvc;

namespace WebPresence.Core.Interfaces
{
    public interface ITemplateInvoker
    {
        string Invoke<M>(HtmlHelper<M> fatherHelper, ViewDataDictionary viewDictionary);
        string Invoke<M>(HtmlHelper<M> fatherHelper, object model, string prefix, string truePrefix = null);
        HtmlHelper BuildHelper(HtmlHelper fatherHelper, object model, string prefix, bool useContextWriter)
    }
}
