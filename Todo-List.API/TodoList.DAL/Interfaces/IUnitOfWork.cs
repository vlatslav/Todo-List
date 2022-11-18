using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DAL.Entity;

namespace TodoList.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IGoalRepository GoalRepository { get; }
        public Task SaveChangesAsync();
    }
}
