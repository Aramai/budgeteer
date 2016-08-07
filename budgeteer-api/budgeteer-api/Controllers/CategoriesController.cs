using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Budgeteer.Api.Models;

namespace Budgeteer.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        Category[] categories = new Category[]
        {
            new Category { CategoryID = 1, Name = "Everyday Expenses", Rank = 1, BudgetID = 1, ParentCategoryID = null },
            new Category { CategoryID = 2, Name = "Monthly Bills", Rank = 2, BudgetID = 1, ParentCategoryID = null },
            new Category { CategoryID = 3, Name = "Savings Goals", Rank = 3, BudgetID = 1, ParentCategoryID = null },
            new Category { CategoryID = 4, Name = "Home Office Expenses", Rank = 1, BudgetID = 2, ParentCategoryID = null },
            new Category { CategoryID = 5, Name = "Travel", Rank = 2, BudgetID = 2, ParentCategoryID = null },
            new Category { CategoryID = 6, Name = "Groceries", Rank = 1, BudgetID = 1, ParentCategoryID = 1 },
            new Category { CategoryID = 7, Name = "Gas/Parking", Rank = 2, BudgetID = 1, ParentCategoryID = 1 },
            new Category { CategoryID = 8, Name = "Rent", Rank = 1, BudgetID = 1, ParentCategoryID = 2 }
        };

        public CategoriesController()
        {
        }

        public CategoriesController(List<Category> newCategories)
        {
            categories = newCategories.ToArray<Category>();
        }

        [HttpGet]
        public IEnumerable<Category> GetCategories(int budgetID)
        {            
            return categories.Where(x => x.BudgetID == budgetID);
        }
    }
}
