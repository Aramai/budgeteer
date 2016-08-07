using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Budgeteer.Api.Models;
using Budgeteer.Api.Controllers;

namespace Budgeteer.Api.Tests
{
    [TestClass]
    public class RouteTests
    {
        HttpConfiguration Configuration { get; set; }

        public RouteTests()
        {
            this.Configuration = new HttpConfiguration();
            this.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Budgeteer.Api.WebApiConfig.Register(this.Configuration);

            this.Configuration.EnsureInitialized();
        }

        [TestMethod]
        public void BudgetsController_GetAll_Correct()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/v1/budgets");

            var routeTester = new RouteTester(this.Configuration, request);

            Assert.AreEqual(typeof(BudgetsController), routeTester.GetControllerType());
            Assert.AreEqual(ReflectionHelpers.GetMethodName((BudgetsController x) => x.GetAllBudgets()), routeTester.GetActionName());
        }

        [TestMethod]
        public void BudgetsController_GetByID_Correct()
        {
            var budgetID = 1;

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/v1/budgets/1");

            var routeTester = new RouteTester(this.Configuration, request);

            Assert.AreEqual(typeof(BudgetsController), routeTester.GetControllerType());
            Assert.AreEqual(ReflectionHelpers.GetMethodName((BudgetsController x) => x.GetBudget(budgetID)), routeTester.GetActionName());
        }

        [TestMethod]
        public void AccountsController_GetAccounts_Correct()
        {
            var budgetID = 1;

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/v1/budgets/1/accounts");

            var routeTester = new RouteTester(this.Configuration, request);

            Assert.AreEqual(typeof(AccountsController), routeTester.GetControllerType());
            Assert.AreEqual(ReflectionHelpers.GetMethodName((AccountsController x) => x.GetAccounts(budgetID)), routeTester.GetActionName());
        }

        [TestMethod]
        public void AccountsController_GetAccountForBudget_Correct()
        {
            var budgetID = 1;
            var accountID = 2;

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/v1/budgets/1/accounts/2");

            var routeTester = new RouteTester(this.Configuration, request);

            Assert.AreEqual(typeof(AccountsController), routeTester.GetControllerType());
            Assert.AreEqual(ReflectionHelpers.GetMethodName((AccountsController x) => x.GetAccountForBudget(budgetID, accountID)), routeTester.GetActionName());
        }

        [TestMethod]
        public void CategoriesController_GetAllCategories_Correct()
        {
            var budgetID = 1;

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/v1/budgets/1/categories");

            var routeTester = new RouteTester(this.Configuration, request);

            Assert.AreEqual(typeof(CategoriesController), routeTester.GetControllerType());
            Assert.AreEqual(ReflectionHelpers.GetMethodName((CategoriesController x) => x.GetCategories(budgetID)), routeTester.GetActionName());
        }
    }
}
