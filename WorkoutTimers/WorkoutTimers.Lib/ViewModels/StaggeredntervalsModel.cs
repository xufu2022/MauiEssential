using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkoutTimers.Lib.Services;

namespace WorkoutTimers.Lib.ViewModels
{
    public class StaggeredIntervalsModel
    {
        IIntervalService _intervalService;
        public StaggeredIntervalsModel(IIntervalService intervalService)
        {
            _intervalService = intervalService;

            AddIntervalCommand = new Command(async () =>
            {
                await (Application.Current.MainPage as Shell).GoToAsync("NewStaggeredInterval");
            });

            RefreshIntervalsCommand = new Command(async () =>
            {
                var items = await _intervalService.GetStaggeredIntervalModelsAsync();
                items.ForEach((i) => Intervals.Add(i));
            });

            MessagingCenter.Instance.Subscribe<NewStaggeredIntervalModel, StaggeredIntervalModel>(this, "NewInterval", (source, newInterval) => {
                this.Intervals.Add(newInterval);
            });
        }
        public ObservableCollection<StaggeredIntervalModel> Intervals { get; set; }  = new ObservableCollection<StaggeredIntervalModel>();

        public ICommand AddIntervalCommand { get; set; }

        public ICommand RefreshIntervalsCommand { get; set; }
    }
}
