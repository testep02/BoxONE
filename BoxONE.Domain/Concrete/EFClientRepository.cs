using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoxONE.Domain.Abstract;
using BoxONE.Domain.Entities;

namespace BoxONE.Domain.Concrete
{
    public class EFClientRepository : IClientRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Client> Clients
        {
            get { return context.Clients; }
        }
    }
}
