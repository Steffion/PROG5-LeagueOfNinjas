﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROG5_LeagueOfNinjas.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LeagueOfNinjasEntities : DbContext
    {
        public LeagueOfNinjasEntities()
            : base("name=LeagueOfNinjasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Loadout> Loadouts { get; set; }
        public virtual DbSet<Ninja> Ninjas { get; set; }
    }
}
