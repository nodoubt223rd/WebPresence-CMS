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
    
    public partial class PhotoBook
    {
        public int Id { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> BookTypeId { get; set; }
        public Nullable<int> BookCategoryId { get; set; }
        public string ItemName { get; set; }
        public string DisplayName { get; set; }
        public Nullable<bool> IsPublished { get; set; }
        public Nullable<bool> IsCacheable { get; set; }
    }
}
