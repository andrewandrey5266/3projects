using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Sql;
using System.Data.Entity.SqlServer;
using System.Globalization;
namespace SportsStore.Context.Migrations
{
    internal class SqlServerMigrationGeneratorField :SqlServerMigrationSqlGenerator
    {
        protected override string Generate(DateTime defaultValue)
        {
            return string.Format("'{0}'",
                defaultValue.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
        }
    }
}
