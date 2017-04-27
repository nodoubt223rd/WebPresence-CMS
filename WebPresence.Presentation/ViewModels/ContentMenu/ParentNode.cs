using System.Collections.Generic;

namespace WebPresence.Presentation.ViewModels.ContentMenu
{
    public class ParentNode
    {
        public ParentNode()
        {
            ChildNodes = new List<ChildNode>();
        }

        public string NodeName { get; set; }
        public int NodeId { get; set; }
        public string Description { get; set; }
        public List<ChildNode> ChildNodes { get; set; }
    }
}
