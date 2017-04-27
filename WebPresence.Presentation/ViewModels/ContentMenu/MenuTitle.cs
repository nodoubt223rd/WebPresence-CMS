using System;

namespace WebPresence.Presentation.ViewModels.ContentMenu
{
    public class MenuTitle : Attribute
    {
        public MenuTitle(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}
