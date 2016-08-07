using Budgeteer.Api.Controllers;
using Budgeteer.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgeteer.Api.Tests.Controller_Tests
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void GetAllCategories_ShouldReturnAllForBudget()
        {
            var budgetID = 1;

            var testCategories = GetTestMasterCategories(budgetID);
            var controller = new CategoriesController(testCategories);

            var result = controller.GetCategories(budgetID).ToList<Category>();
            Assert.AreEqual(testCategories.Count, result.Count);
        }

        private List<Category> GetTestMasterCategories(int budgetID)
        {
            Category[] masterCategories = new Category[]
            {
                new Category { CategoryID = 1, Name = "Everyday Expenses", Rank = 1, BudgetID = 1 },
                new Category { CategoryID = 2, Name = "Monthly Bills", Rank = 2, BudgetID = 1 },
                new Category { CategoryID = 3, Name = "Savings Goals", Rank = 3, BudgetID = 1 },
                new Category { CategoryID = 4, Name = "Home Office Expenses", Rank = 1, BudgetID = 2 },
                new Category { CategoryID = 5, Name = "Travel", Rank = 2, BudgetID = 2 }
            };

            return masterCategories.Where(x => x.BudgetID == budgetID).ToList<Category>();
        }
    }
}
