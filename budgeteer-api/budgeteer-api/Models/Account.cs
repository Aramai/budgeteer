using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Budgeteer.Api.Models
{
    public enum AccountStatus { Open, Closed }
    public enum AccountLocation { OnBudget, OffBudget }

    public class Account
    {
        
        public int AccountID { get; set; }
        public int BudgetID { get; set; }
        public string Name { get; set; }
        public AccountStatus Status { get; set; }
        public AccountLocation Location { get; set; }
    }
}