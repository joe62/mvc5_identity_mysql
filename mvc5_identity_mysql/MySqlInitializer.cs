using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5
{
    public class MySqlInitializer:IDatabaseInitializer<ApplicationDbContext>
    {
        
        public void InitializeDatabase(ApplicationDbContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
            }
            else
            {
                //var strQuery = string.Format("SELECT COUNT(*) FROM　information_schema.tables WHERE table_schem='{0}' AND table_name='__MigrationHistory'",

                //    "[Insert your database schema here - such as 'users']");

                var strQuery = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'itop22' AND table_name = '__MigrationHistory'";

                var migrationHistoryTableExits
                    = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(strQuery);

                if (migrationHistoryTableExits.FirstOrDefault() == 0)
                {
                    context.Database.Delete();
                    context.Database.Create();

                }
            }
        }
    }
}