namespace Ddd.DotNet.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ddd.DotNet.Data.Contexto.DddDotNetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Ddd.DotNet.Data.Contexto.DddDotNetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Clients.AddOrUpdate(
                  p => p.Id,
                  new Domain.Entities.Client { Name = "Andrew Peters", CpfCnpj = "279150123123", Phone = "12356123" },
                  new Domain.Entities.Client { Name = "Brice Lambson", CpfCnpj = "279150123123", Phone = "12356123" },
                  new Domain.Entities.Client { Name = "Rowan Miller", CpfCnpj = "279150123123", Phone = "12356123" }
                );
        }
    }
}
