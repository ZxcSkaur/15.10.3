using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MotorbikeApp.ModelEF
{
    public partial class MotorbikeDB : DbContext
    {
        public MotorbikeDB()
            : base("name=АПВЧВЫЦОУА")
        {
        }

        public virtual DbSet<Table_1> Table_1 { get; set; }
        public virtual DbSet<Table_Motorbike> Table_Motorbike { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
