using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Moq;
using Ninject;

using BoxONE.Domain.Abstract;
using BoxONE.Domain.Concrete;
using BoxONE.Domain.Entities;


namespace BoxONE.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            /**
             * This is some test data that can be used in place of a DB connection.
             * It uses MOCK objects instead of data from the actual database connection.
             * 
            Mock<IClientRepository> mock = new Mock<IClientRepository>();

            mock.Setup(m => m.Clients).Returns(new List<Client> {
                new Client { FirstName = "Travis", MiddleName = "Boone", LastName = "Estep", DOB = "06/16/1982", Active = 1, StartDate = "01/01/2000", EndDate = "", SSN = "400-35-8966", 
                    ClientID = 1 },
                new Client { FirstName = "John", MiddleName = "Friggin", LastName = "Doe", DOB = "09/10/1984", Active = 1, StartDate = "02/02/2000", EndDate = "", SSN = "499-88-7777", 
                    ClientID = 2 },
                new Client { FirstName = "Jane", MiddleName = "Freaking", LastName = "Smith", DOB = "08/09/1969", Active = 1, StartDate = "03/03/2000", EndDate = "", SSN = "999-77-0001", 
                    ClientID = 3 },
                new Client { FirstName = "Bob", MiddleName = "Johnson", LastName = "Hope", DOB = "03/03/1901", Active = 1, StartDate = "01/16/2012", EndDate = "", SSN = "222-22-2222", 
                    ClientID = 4 }
            }.AsQueryable());

            ninjectKernel.Bind<IClientRepository>().ToConstant(mock.Object);
             * 
             * */

            ninjectKernel.Bind<IClientRepository>().To<EFClientRepository>();
        }
    }
}