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
    public class AccountTest
    {
        [TestMethod]
        public void GetAccounts_ReturnAccountList()
        {
            int budgetID = 1;

            var testAccounts = GetTestAccounts(budgetID);
            var controller = new AccountsController(testAccounts);

            var result = controller.GetAccounts(budgetID).ToList<Account>();
            
            Assert.AreEqual(testAccounts.Count, result.Count);
        }

        private List<Account> GetTestAccounts(int budgetID)
        {
            Account[] accounts = new Account[]
            {
                new Account { AccountID = 1, BudgetID = 1, Name = "Chequing", Status = AccountStatus.Open, Location = AccountLocation.OnBudget },
                new Account { AccountID = 2, BudgetID = 1, Name = "Savings", Status = AccountStatus.Open, Location = AccountLocation.OnBudget },
                new Account { AccountID = 3, BudgetID = 1, Name = "Credit Card", Status = AccountStatus.Closed, Location = AccountLocation.OnBudget },
                new Account { AccountID = 4, BudgetID = 1, Name = "Investment", Status = AccountStatus.Open, Location = AccountLocation.OffBudget },
                new Account { AccountID = 5, BudgetID = 2, Name = "Chequing 2", Status = AccountStatus.Open, Location = AccountLocation.OnBudget }
            };

            var accountsList = accounts.ToArray<Account>();

            return accountsList.Where(x => x.BudgetID == budgetID).ToList<Account>();
        }
    }
}
