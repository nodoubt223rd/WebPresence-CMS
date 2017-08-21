using System.Collections.Generic;

namespace WebPresence.Presentation.ViewModels.ContentMenu
{
    public class ContentTree
    {
		public ParentNode ContentNode { get; set; }

        public List<ParentNode>ContentTreeNodes { get; set; }
    }
}
