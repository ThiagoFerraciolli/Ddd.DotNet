using Ddd.DotNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Data.EntityConfig
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Name).IsRequired().HasMaxLength(150);

            Property(c => c.CpfCnpj).IsRequired().HasMaxLength(20);
        }
    }
}
