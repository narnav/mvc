﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShoppingCartEntities2 : DbContext
    {
        public ShoppingCartEntities2()
            : base("name=ShoppingCartEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CateProd> CateProd { get; set; }
        public DbSet<users> users { get; set; }
    }
}
