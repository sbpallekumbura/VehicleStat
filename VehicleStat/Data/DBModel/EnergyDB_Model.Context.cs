﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VehicleStat.Data.DBModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class energy_dbEntities : DbContext
    {
        public energy_dbEntities()
            : base("name=energy_dbEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            var objectContext = (this as IObjectContextAdapter).ObjectContext;

            // Sets the command timeout for all the commands
            objectContext.CommandTimeout = 120;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_emission_test> tbl_emission_test { get; set; }
        public DbSet<tbl_search_key> tbl_search_key { get; set; }
        public DbSet<tbl_urban> tbl_urban { get; set; }
    }
}
