using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using WebPresence.Common.Resources;
using WebPresence.Core.Controls.Bindings.Interfaces;
using WebPresence.Core.Interfaces;

namespace WebPresence.Core
{
    public class TemplateInvoker<T> : IViewDataContainer, ITemplateInvoker
    {
        private string fileTemplate;
        private Func<HtmlHelper<T>, string> functionTemplate;
        private IBindingBuilder<T> bindings = null;

        public TemplateInvoker(object template)
        {
            functionTemplate = template as Func<HtmlHelper<T>, string>;
            fileTemplate = template as string;
            if (functionTemplate == null && fileTemplate == null)
                throw (new ArgumentException(CoreResources.templateNotValid));
        }
        public TemplateInvoker(object template, IBindingBuilder<T> bindings)
        {
            functionTemplate = template as Func<HtmlHelper<T>, string>;
            fileTemplate = template as string;
            if (functionTemplate == null && fileTemplate == null)
                throw (new ArgumentException(CoreResources.templateNotValid));
            this.bindings = bindings;
        }
        public TemplateInvoker()
        {
        }
        internal static Type ExtractModelType(object template)
        {

            string fileTemplate = template as string;
            if (fileTemplate == null)
            {
                Type[] res = template.GetType().GetGenericArguments();
                if (res.Length == 0)
                {
                    throw (new ArgumentException(CoreResources.NotIstantiatedType));
                }
                else
                {
                    res = res[0].GetGenericArguments();
                    if (res.Length == 0 || res[0].ContainsGenericParameters)
                        throw (new ArgumentException(CoreResources.NotIstantiatedType));
                    return res[0];
                }
            }

            else
            {
                throw (new ArgumentException(CoreResources.TypeSafeTemplateNotValid));
            }
        }
        public HtmlHelper<T> BuildHelper(HtmlHelper parentHelper, ViewDataDictionary viewDictionary, bool useContextWriter = false)
        {
            ControllerContext controllerContext = new ControllerContext
                    (
                        parentHelper.ViewContext.HttpContext,
                        parentHelper.ViewContext.RouteData,
                        parentHelper.ViewContext.Controller
                    );
            ViewContext viewContext = new ViewContext(
                controllerContext,
                parentHelper.ViewContext.View,
                viewDictionary,
                parentHelper.ViewContext.TempData,
                useContextWriter ? (contextWriter = new System.IO.StringWriter()) : parentHelper.ViewContext.Writer

                    );
            viewContext.ClientValidationEnabled = parentHelper.ViewContext.ClientValidationEnabled;
            viewContext.FormContext = parentHelper.ViewContext.FormContext;
            this.ViewData = viewDictionary;
            if (bindings != null) viewDictionary["ClientBindings"] = bindings;
            return new HtmlHelper<T>(
            viewContext,
            this
            );
        }
        public HtmlHelper BuildHelper(HtmlHelper parentHelper, object model, string prefix, bool useContextWriter = false)
        {
            T tModel = default(T);
            if (model != null) tModel = (T)model;
            ViewDataDictionary<T> dataDictionary = new ViewDataDictionary<T>(tModel);
            dataDictionary.TemplateInfo.HtmlFieldPrefix = prefix;
            CoreHtmlHelper.CopyRelevantErrors(dataDictionary.ModelState, parentHelper.ViewData.ModelState, dataDictionary.TemplateInfo.HtmlFieldPrefix);
            return BuildHelper(parentHelper, dataDictionary, useContextWriter);
        }
        public string Invoke<M>(HtmlHelper<M> parentHelper, ViewDataDictionary viewDictionary)
        {

            if (fileTemplate != null)
            {
                if (bindings != null) viewDictionary["ClientBindings"] = bindings;
                string res = parentHelper.Partial(fileTemplate, viewDictionary).ToString();
                return res;
            }
            else if (functionTemplate != null)
            {
                string res = functionTemplate(BuildHelper(parentHelper, viewDictionary, true));
                contextWriter.Write(res);
                return contextWriter.ToString();
            }
            return string.Empty;
        }
        private string InnerInvoke(HtmlHelper parentHelper, ViewDataDictionary viewDictionary)
        {

            if (fileTemplate != null)
            {
                if (bindings != null) viewDictionary["ClientBindings"] = bindings;
                string res = parentHelper.Partial(fileTemplate, viewDictionary).ToString();
                return res;
            }

            else if (functionTemplate != null)
            {
                string res = functionTemplate(BuildHelper(parentHelper, viewDictionary, true));
                contextWriter.Write(res);
                return contextWriter.ToString();
            }
            return string.Empty;
        }
        public string Invoke<M>(HtmlHelper<M> parentHelper, T model, string prefix, string truePrefix = null)
        {
            ViewDataDictionary<T> dataDictionary = new ViewDataDictionary<T>(model);
            dataDictionary.TemplateInfo.HtmlFieldPrefix = prefix;
            if (truePrefix != null) dataDictionary["_TruePrefix_"] = truePrefix;
            CoreHtmlHelper.CopyRelevantErrors(dataDictionary.ModelState, parentHelper.ViewData.ModelState, dataDictionary.TemplateInfo.HtmlFieldPrefix);

            return Invoke(parentHelper, dataDictionary);
        }
        public string InvokeNM(HtmlHelper parentHelper, ViewDataDictionary viewDictionary)
        {

            if (fileTemplate != null)
            {
                if (bindings != null) viewDictionary["ClientBindings"] = bindings;
                string res = parentHelper.Partial(fileTemplate, viewDictionary).ToString();
                return res;
            }
            else if (functionTemplate != null)
            {
                string res = functionTemplate(BuildHelper(parentHelper, viewDictionary, true));
                contextWriter.Write(res);
                return contextWriter.ToString();
            }
            return string.Empty;
        }
        public string InvokeNM(HtmlHelper parentHelper, T model, string prefix)
        {
            ViewDataDictionary<T> dataDictionary = new ViewDataDictionary<T>(model);
            dataDictionary.TemplateInfo.HtmlFieldPrefix = prefix;
            CoreHtmlHelper.CopyRelevantErrors(dataDictionary.ModelState, parentHelper.ViewData.ModelState, dataDictionary.TemplateInfo.HtmlFieldPrefix);

            return InvokeNM(parentHelper, dataDictionary);
        }
        public string InvokeVirtual(HtmlHelper parentHelper, string prefix)
        {
            T model = default(T);
            Type basicType = typeof(T);
            if (basicType.IsClass)
            {
                var constructor = basicType.GetConstructor(new Type[0]);
                if (constructor != null) model = (T)constructor.Invoke(new object[0]);
            }
            ViewDataDictionary<T> dataDictionary = new ViewDataDictionary<T>(model);
            dataDictionary["_TemplateLevel_"] = 0;
            dataDictionary.TemplateInfo.HtmlFieldPrefix = prefix;
            return InnerInvoke(parentHelper, dataDictionary);
        }
        public string Invoke<M>(HtmlHelper<M> parentHelper, object model, string prefix, string truePrefix = null)
        {
            return Invoke<M>(parentHelper, (T)model, prefix, truePrefix);
        }
        private System.IO.StringWriter contextWriter;
        ViewDataDictionary _ViewData;
        public ViewDataDictionary ViewData
        {
            get
            {
                return _ViewData;
            }
            set
            {
                _ViewData = value;
            }
        }
    }
}
