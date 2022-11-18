using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.BLL.Models;

namespace TodoList.BLL.Interfaces
{
    public interface IGoalService: ICrud<GoalModel>
    {
        public Task SetDone(int modelId, bool value);
    }
}
