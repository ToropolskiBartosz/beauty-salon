﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GabinetKosmetyczny
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Gabinet_Kosmetyczny_DBEntities : DbContext
    {
        public Gabinet_Kosmetyczny_DBEntities()
            : base("name=Gabinet_Kosmetyczny_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<gabinety> gabinety { get; set; }
        public virtual DbSet<klienci> klienci { get; set; }
        public virtual DbSet<pracownicy> pracownicy { get; set; }
        public virtual DbSet<produkty> produkty { get; set; }
        public virtual DbSet<produkty_do_zabiegu> produkty_do_zabiegu { get; set; }
        public virtual DbSet<typ_zabiegu> typ_zabiegu { get; set; }
        public virtual DbSet<zabiegi> zabiegi { get; set; }
    }
}
