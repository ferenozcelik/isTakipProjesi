﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace isTakipProjesi.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbisTakipEntities : DbContext
    {
        public DbisTakipEntities()
            : base("name=DbisTakipEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblAdmin> TblAdmin { get; set; }
        public virtual DbSet<TblDepartmanlar> TblDepartmanlar { get; set; }
        public virtual DbSet<TblFirmalar> TblFirmalar { get; set; }
        public virtual DbSet<TblGorevDetaylar> TblGorevDetaylar { get; set; }
        public virtual DbSet<TblGorevler> TblGorevler { get; set; }
        public virtual DbSet<TblPersonel> TblPersonel { get; set; }
        public virtual DbSet<TblCagrilar> TblCagrilar { get; set; }
    }
}
