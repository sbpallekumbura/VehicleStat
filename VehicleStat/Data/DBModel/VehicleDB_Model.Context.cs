namespace VehicleStat.Data.DBModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class vehicle_dbEntities : DbContext
    {
        public vehicle_dbEntities()
            : base("name=vehicle_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<vehicle> vehicles { get; set; }
    }
}
