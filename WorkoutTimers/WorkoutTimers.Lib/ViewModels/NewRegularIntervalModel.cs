using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkoutTimers.Lib.Services;

namespace WorkoutTimers.Lib.ViewModels
{
    public class NewRegularIntervalModel
    {
        IIntervalService _intervalService;
        
        public NewRegularIntervalModel(IIntervalService service)
        {
            _intervalService = service;
            Model = new RegularIntervalModel();

            SaveIntervalCommand = new Command(() => {
                _intervalService.AddRegularIntervalModel(Model);
                MessagingCenter.Instance.Send<NewRegularIntervalModel, RegularIntervalModel>(this, "NewInterval", Model);
                (Application.Current.MainPage as Shell).SendBackButtonPressed();
            });
        }

        public RegularIntervalModel Model { get; private set; }

        public ICommand SaveIntervalCommand { get; private set; }
    }
}
