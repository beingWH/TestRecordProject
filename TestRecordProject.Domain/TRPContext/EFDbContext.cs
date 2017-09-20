using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRecordProject.Domain.Entities;

namespace TestRecordProject.Domain.TRPContext
{
    public class EFDbContext:DbContext
    {
        public EFDbContext() : base("TRPConnection") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer<EFDbContext>(new DropCreateDatabaseIfModelChanges<EFDbContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Test> tests { get; set; }

    }
   
}
