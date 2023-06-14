using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTimers.Lib.ViewModels;

namespace WorkoutTimers.Lib.Services
{
    public interface IIntervalService
    {
        Task<List<RegularIntervalModel>> GetRegularIntervalModelsAsync();

        Task<List<StaggeredIntervalModel>> GetStaggeredIntervalModelsAsync();

        Task AddRegularIntervalModel (RegularIntervalModel model);

        Task AddStaggeredIntervalModel (StaggeredIntervalModel model);  
    }
}
