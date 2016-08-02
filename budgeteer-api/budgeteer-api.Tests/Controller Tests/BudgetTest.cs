using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Budgeteer.Api.Models;
using Budgeteer.Api.Controllers;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Budgeteer.Api.Tests
{
    [TestClass]
    public class BudgetTest
    {
        [TestMethod]
        public void GetAllBudgets_ShouldReturnAllProducts()
        {
            var testBudgets = GetTestBudgets();
            var controller = new BudgetsController(testBudgets);

            var result = controller.GetAllBudgets().ToList<Budget>();
            Assert.AreEqual(testBudgets.Count, result.Count);
        }

        [TestMethod]
        public void GetBudget_ShouldFindBudget()
        {
            var testBudgets = GetTestBudgets();
            var controller = new BudgetsController(testBudgets);

            var result = controller.GetBudget(1) as OkNegotiatedContentResult<Budget>; ;
            Assert.AreEqual(testBudgets[0].Name, result.Content.Name);
        }

        [TestMethod]
        public void GetBudget_ShouldNotFindBudget()
        {
            var testBudgets = GetTestBudgets();
            var controller = new BudgetsController(testBudgets);

            var result = controller.GetBudget(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Budget> GetTestBudgets()
        {            
            Budget[] budgets = new Budget[]
            {
                new Budget { BudgetID = 1, Name = "Household" },
                new Budget { BudgetID = 2, Name = "Side Business" }
            };

            return new List<Budget>(budgets);
        }
    }
}
