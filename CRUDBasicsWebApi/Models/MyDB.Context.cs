﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUDBasicsWebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CrudBasicsEntities : DbContext
    {
        public CrudBasicsEntities()
            : base("name=CrudBasicsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<playerAverage> playerAverages { get; set; }
        public virtual DbSet<customPlayer> customPlayers { get; set; }
        public virtual DbSet<playerAverageMin50Games> playerAverageMin50Games { get; set; }
        public virtual DbSet<playersSeason> playersSeasons { get; set; }
    }
}
