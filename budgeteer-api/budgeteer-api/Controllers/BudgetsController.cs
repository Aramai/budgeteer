using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Budgeteer.Api.Models;

namespace Budgeteer.Api.Controllers
{
    public class BudgetsController : ApiController
    {
        Budget[] budgets = new Budget[]
        {
            new Budget { BudgetID = 1, Name = "Household" },
            new Budget { BudgetID = 2, Name = "Side Business" }
        };

        public BudgetsController()
        {
        }

        public BudgetsController(List<Budget> newBudgets)
        {
            budgets = newBudgets.ToArray();
        }

        public IEnumerable<Budget> GetAllBudgets()
        {
            return budgets;
        }

        public IHttpActionResult GetBudget(int id)
        {
            var budget = budgets.FirstOrDefault((p) => p.BudgetID == id);
            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget);
        }
    }
}
