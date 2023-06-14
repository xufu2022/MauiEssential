using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkoutTimers.Lib.Services;

namespace WorkoutTimers.Lib.ViewModels
{
    public  class NewStaggeredIntervalModel
    {
        IIntervalService _intervalService;

        public NewStaggeredIntervalModel(IIntervalService service)
        {
            _intervalService = service;
            Model = new StaggeredIntervalModel();

            SaveIntervalCommand = new Command(() => {
                _intervalService.AddStaggeredIntervalModel(Model);
                MessagingCenter.Instance.Send<NewStaggeredIntervalModel, StaggeredIntervalModel>(this, "NewInterval", Model);
                (Application.Current.MainPage as Shell).SendBackButtonPressed();
            });

            NewDurationCommand = new Command(() => {
                Model.Durations.Add(TimeSpan.FromSeconds(30));
            });
        }

        public StaggeredIntervalModel Model { get; private set; }

        public ICommand SaveIntervalCommand { get; private set; }
        public ICommand NewDurationCommand { get; private set; }
    }
}
