namespace WorkoutTimers.App.Views;

public partial class RegularIntervals : ContentPage
{
	public RegularIntervals(Lib.ViewModels.RegularIntervalsModel model)
	{
		InitializeComponent();
		BindingContext = model;
		model.RefreshIntervalsCommand.Execute(null);
	}
}