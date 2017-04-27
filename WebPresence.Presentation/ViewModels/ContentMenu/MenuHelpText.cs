using System;

namespace WebPresence.Presentation.ViewModels.ContentMenu
{
    public class MenuHelpText : Attribute
    {
        public MenuHelpText(string helpText)
        {
            HelpText = helpText;
        }

        public string HelpText { get; set; }
    }
}
