using System.Collections.Generic;
using expense_tracking_api.Infrastructure;

namespace expense_tracking_api.Domain
{
    public class ExpenseType : ArchivableEntity
    {
        protected ExpenseType()
        {
        }

        public ExpenseType(
            string name,
            string description,
            User user)
        {
            Name = name;
            Description = description;
            User = user;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}