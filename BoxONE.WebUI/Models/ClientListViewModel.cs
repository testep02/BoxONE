using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BoxONE.Domain.Entities;

namespace BoxONE.WebUI.Models
{
    public class ClientListViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}