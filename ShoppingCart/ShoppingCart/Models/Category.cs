//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingCart.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public Category()
        {
            this.Products = new HashSet<Products>();
        }
    
        public int CategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public string imgSrc { get; set; }
    
        public virtual ICollection<Products> Products { get; set; }
    }
}
