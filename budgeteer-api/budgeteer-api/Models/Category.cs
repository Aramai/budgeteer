using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budgeteer.Api.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public int BudgetID { get; set; }
        public int Rank { get; set; }
        public int? ParentCategoryID { get; set; }

    }
}