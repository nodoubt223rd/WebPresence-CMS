using System;

namespace WebPresence.Presentation.ViewModels.ContentMenu
{
    public class ChildNode
    {
        public int Id { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public int? ParentItemId { get; set; }
        public int ItemTypeId { get; set; }
        public string ItemName { get; set; }
        public string DisplayName { get; set; }
        public DateTime Created { get; set; }
        public string ContentOwner { get; set; }
        public string Url { get; set; }
        public bool Disable { get; set; }
        public bool HasAccess { get; set; }
        public ParentNode ParentMenu { get; set; }
    }
}
