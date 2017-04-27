using System.Xml;

namespace WebPresence.Common
{
    public static class XmlElementUtils
    {
        public static void AddTextElement(XmlDocument doc, XmlElement parent, string elemName, string text)
        {
            XmlElement newElem = doc.CreateElement(elemName);
            newElem.InnerText = text;
            parent.AppendChild(newElem);
        }
    }
}
