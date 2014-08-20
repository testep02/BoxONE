using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BoxONE.Domain.Abstract;
using BoxONE.Domain.Entities;
using BoxONE.WebUI.Models;

namespace BoxONE.WebUI.Controllers
{
    public class ClientController : Controller
    {
        private IClientRepository repository;
        public int PageSize = 4;

        public ClientController(IClientRepository clientRepository)
        {
            this.repository = clientRepository;
        }

        public ViewResult List(int page = 1)
        {
            ClientListViewModel model = new ClientListViewModel
            {
                Clients = repository.Clients
                .OrderBy(c => c.ClientID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Clients.Count()
                }
            };

            return View(model);
        }

        public ViewResult Summary(int clientId = 1)
        {
            Client client = repository.Clients.FirstOrDefault(c => c.ClientID == clientId);
            return View(client);
        }

    }
}
