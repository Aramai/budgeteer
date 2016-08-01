using Budgeteer.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Budgeteer.Api.Controllers
{
    public class AccountsController : ApiController
    {
        Account[] accounts = new Account[]
        {
            new Account { AccountID = 1, BudgetID = 1, Name = "Chequing", Status = AccountStatus.Open, Location = AccountLocation.OnBudget },
            new Account { AccountID = 2, BudgetID = 1, Name = "Savings", Status = AccountStatus.Open, Location = AccountLocation.OnBudget },
            new Account { AccountID = 3, BudgetID = 1, Name = "Credit Card", Status = AccountStatus.Closed, Location = AccountLocation.OnBudget },
            new Account { AccountID = 4, BudgetID = 1, Name = "Investment", Status = AccountStatus.Open, Location = AccountLocation.OffBudget },
            new Account { AccountID = 5, BudgetID = 2, Name = "Chequing 2", Status = AccountStatus.Open, Location = AccountLocation.OnBudget }
        };

        public AccountsController()
        {
        }

        public AccountsController(List<Account> newAccounts)
        {
            accounts = newAccounts.ToArray();
        }

        [HttpGet]
        public IEnumerable<Account> GetAccounts(int budgetID)
        {
            return accounts.Where(x => x.BudgetID == budgetID);
        }
    }
}
