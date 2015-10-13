using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Web;

namespace WebApplication5
{
    public class MySqlHistoryContext:HistoryContext
    {
        public MySqlHistoryContext(DbConnection exitingConnection,string defaultSchema)
            :base(exitingConnection,defaultSchema)
        { }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();
        }
    }
}