//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebPresence.Domain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int Id { get; set; }
        public Nullable<int> ParentItemId { get; set; }
        public int ItemTypeId { get; set; }
        public string ItemName { get; set; }
        public string DisplayName { get; set; }
        public System.DateTime Created { get; set; }
        public string ContentOwner { get; set; }
        public bool IsParentItem { get; set; }
        public bool IsChild { get; set; }    
    }
}
