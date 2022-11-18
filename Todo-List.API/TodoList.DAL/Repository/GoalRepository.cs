using Microsoft.EntityFrameworkCore;
using TodoList.DAL.Entity;
using TodoList.DAL.Interfaces;

namespace TodoList.DAL.Repository
{
    public class GoalRepository : IGoalRepository
    {
        private readonly ApplicationDbContext _context;

        public GoalRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Goal model)
        {
            if(model is null)
                throw new ArgumentNullException("model is null");
            if (_context.Goals.ToList().Select(x => x.Aim.ToLower()).Contains(model.Aim.ToLower()))
                throw new ArgumentException("Allready exists in database");
            await _context.Goals.AddAsync(model);
        }

        public async Task DeleteByIdAsync(int modelid)
        {
            var concrateGoal = await _context.Goals.FirstOrDefaultAsync(x => x.Id == modelid);
            if(concrateGoal is null)
                throw new ArgumentException("Incorrect id");
            _context.Goals.Remove(concrateGoal);
        }

        public async Task<IEnumerable<Goal>> GetAll()
        {
            var allGoals = await _context.Goals.ToArrayAsync();
            return allGoals;
        }

        public async Task<Goal> GetById(int modelid)
        {
            var concrateGoal = await _context.Goals.FirstOrDefaultAsync(x => x.Id == modelid);

            if (concrateGoal is null)
                throw new ArgumentException("Incorrect id");
            return concrateGoal;
        }

        public async Task SetDone(int modelid, bool value)
        {
            var concrateGoal = await _context.Goals.FirstOrDefaultAsync(x => x.Id == modelid);
            if (concrateGoal is null)
                throw new ArgumentException("Incorrect id");
            concrateGoal.IsDone = value;
        }

        public void Update(Goal model)
        {
            if (model is null)
                throw new ArgumentNullException("model is null");
            _context.Goals.Update(model);
        }
    }
}
