namespace CK1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CK1.QLDHP>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CK1.QLDHP";
        }

        protected override void Seed(CK1.QLDHP context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
