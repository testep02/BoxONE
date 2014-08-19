using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Moq;

using BoxONE.Domain.Abstract;
using BoxONE.Domain.Entities;
using BoxONE.WebUI.Controllers;
using BoxONE.WebUI.HtmlHelpers;
using BoxONE.WebUI.Models;

namespace BoxONE.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IClientRepository> mock = getClientMockRepo();

            ClientController controller = new ClientController(mock.Object);
            controller.PageSize = 3;

            ClientListViewModel result = (ClientListViewModel)controller.List(2).Model;

            Client[] clientArray = result.Clients.ToArray();
            Assert.IsTrue(clientArray.Length == 2);
            Assert.AreEqual(clientArray[0].FirstName, "C4");
            Assert.AreEqual(clientArray[1].FirstName, "C5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;

            PagingInfo pagingInfo = new PagingInfo { CurrentPage = 2, TotalItems = 28, ItemsPerPage = 10 };

            Func<int, string> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>"
                + @"<a class=""selected"" href=""Page2"">2</a>"
                + @"<a href=""Page3"">3</a>");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IClientRepository> mock = getClientMockRepo();

            ClientController controller = new ClientController(mock.Object);
            controller.PageSize = 3;

            ClientListViewModel result = (ClientListViewModel)controller.List(2).Model;

            PagingInfo pagingInfo = result.PagingInfo;

            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }

        private Mock<IClientRepository> getClientMockRepo()
        {
            Mock<IClientRepository> mock = new Mock<IClientRepository>();
            mock.Setup(m => m.Clients).Returns(new Client[] {
                new Client {ClientID = 1, FirstName = "C1", MiddleName = "", LastName = "", DOB = "", SSN = "", StartDate = "", EndDate = "", Active = 1},
                new Client {ClientID = 2, FirstName = "C2", MiddleName = "", LastName = "", DOB = "", SSN = "", StartDate = "", EndDate = "", Active = 1},
                new Client {ClientID = 3, FirstName = "C3", MiddleName = "", LastName = "", DOB = "", SSN = "", StartDate = "", EndDate = "", Active = 1},
                new Client {ClientID = 4, FirstName = "C4", MiddleName = "", LastName = "", DOB = "", SSN = "", StartDate = "", EndDate = "", Active = 1},
                new Client {ClientID = 5, FirstName = "C5", MiddleName = "", LastName = "", DOB = "", SSN = "", StartDate = "", EndDate = "", Active = 1}
            }.AsQueryable());

            return mock;
        }
    }
}
