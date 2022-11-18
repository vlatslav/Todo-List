using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DAL.Entity;

namespace TodoList.DAL.Validation
{
    public class GoalValidator : AbstractValidator<Goal>
    {
        public GoalValidator()
        {
            RuleFor(u => u.Aim).NotNull().NotEmpty();
        }
    }
}
