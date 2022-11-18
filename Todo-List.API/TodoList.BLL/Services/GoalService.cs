using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.BLL.Interfaces;
using TodoList.BLL.Models;
using TodoList.DAL.Entity;
using TodoList.DAL.Interfaces;

namespace TodoList.BLL.Services
{
    public class GoalService : IGoalService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GoalService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddAsync(GoalModel model)
        {
            if(model.Aim == String.Empty)
                throw new ArgumentException("Your aim can't be null");
            await _uow.GoalRepository.Add(_mapper.Map<Goal>(model));
            await _uow.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int Id)
        {
            await _uow.GoalRepository.DeleteByIdAsync(Id);
            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<GoalModel>> GetAllAsync()
        {
            var allGoals =  await _uow.GoalRepository.GetAll();
            return _mapper.Map<IEnumerable<GoalModel>>(allGoals);
        }

        public async Task<GoalModel> GetByIdAsync(int id)
        {
            var concrateGoal = await _uow.GoalRepository.GetById(id);
            return _mapper.Map<GoalModel>(concrateGoal);
        }

        public async Task SetDone(int modelId, bool value)
        {
            await _uow.GoalRepository.SetDone(modelId, value);
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(GoalModel model)
        {
            if(model.Aim == String.Empty)
                throw new ArgumentException("Your aim can't be null");
            _uow.GoalRepository.Update(_mapper.Map<Goal>(model));
            await _uow.SaveChangesAsync();
        }
    }
}
