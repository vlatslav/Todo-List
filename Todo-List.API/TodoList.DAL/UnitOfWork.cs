using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.DAL.Entity;
using TodoList.DAL.Interfaces;
using TodoList.DAL.Repository;

namespace TodoList.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IGoalRepository goalRepository;
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGoalRepository GoalRepository
        {
            get
            {
                if (goalRepository is null)
                    goalRepository = new GoalRepository(_context);
                return goalRepository;
            }
        } 

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
