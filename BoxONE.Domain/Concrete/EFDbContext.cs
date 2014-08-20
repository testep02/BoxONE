using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoxONE.Domain.Entities;

namespace BoxONE.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }
}
