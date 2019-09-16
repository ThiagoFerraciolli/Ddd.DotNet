using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddd.DotNet.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CpfCnpj { get; set; }

        public string Phone { get; set; }

        public DateTime RegistryDate { get; set; }
    }
}
