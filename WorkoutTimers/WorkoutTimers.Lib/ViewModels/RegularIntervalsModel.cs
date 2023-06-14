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
    public class RegularIntervalsModel
    {
        IIntervalService _intervalService;

        public RegularIntervalsModel(IIntervalService intervalService)
        {
            _intervalService = intervalService;
            
            AddIntervalCommand = new Command(async () => {

                await (Application.Current.MainPage as Shell).GoToAsync("NewRegularInterval");
            });

            RefreshIntervalsCommand = new Command(async () => {
                var intervals = await _intervalService.GetRegularIntervalModelsAsync();
                intervals.ForEach((i) => Intervals.Add(i));
            });

            MessagingCenter.Instance.Subscribe<NewRegularIntervalModel, RegularIntervalModel>(this, "NewInterval", (source,newInterval) => {
                this.Intervals.Add(newInterval);
            });
        }
        public ObservableCollection<RegularIntervalModel> Intervals { get; set; } = new ObservableCollection<RegularIntervalModel>();

        public ICommand AddIntervalCommand { get; set; }

        public ICommand RefreshIntervalsCommand { get; set; }
    }
}
