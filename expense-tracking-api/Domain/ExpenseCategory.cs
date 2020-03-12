﻿using System.Collections.Generic;
using expense_tracking_api.Infrastructure;

namespace expense_tracking_api.Domain
{
    public class ExpenseCategory : ArchivableEntity
    {
        protected ExpenseCategory()
        {
        }

        public ExpenseCategory(
            string name,
            string description,
            decimal budget,
            string colourHex,
            User user)
        {
            Name = name;
            Description = description;
            Budget = budget;
            ColourHex = colourHex;
            User = user;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public string ColourHex { get; set; }
        public User User { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}