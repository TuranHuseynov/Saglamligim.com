﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AzmanAzWebPage.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_A3E145_SaglamligimEntities : DbContext
    {
        public DB_A3E145_SaglamligimEntities()
            : base("name=DB_A3E145_SaglamligimEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adresim> Adresims { get; set; }
        public virtual DbSet<Elaqe> Elaqes { get; set; }
        public virtual DbSet<Endirim> Endirims { get; set; }
        public virtual DbSet<Karusel> Karusels { get; set; }
        public virtual DbSet<Kategoriya> Kategoriyas { get; set; }
        public virtual DbSet<Servi> Servis { get; set; }
        public virtual DbSet<Slayder> Slayders { get; set; }
        public virtual DbSet<Mallar> Mallars { get; set; }
        public virtual DbSet<Galereya> Galereyas { get; set; }
        public virtual DbSet<Zakazim> Zakazims { get; set; }
        public virtual DbSet<Zakaznovu> Zakaznovus { get; set; }
        public virtual DbSet<MalNovu> MalNovus { get; set; }
        public virtual DbSet<Kampanya> Kampanyas { get; set; }
    }
}
