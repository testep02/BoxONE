using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoxONE.Domain.Entities;

namespace BoxONE.Domain.Abstract
{
    public interface IClientRepository
    {
        IQueryable<Client> Clients { get; }
    }
}
