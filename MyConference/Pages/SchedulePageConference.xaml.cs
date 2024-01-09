using Microsoft.Maui.Controls;
using MyConference.Models;
using MyConference.ViewModels;

namespace MyConference.Pages;

public partial class ScheduleDayCong1Page : SchedulePageConference
{
	public ScheduleDayCong1Page(ConferenceViewModel vmm) : base()
	{
        vmm.Day = 1;
        Title = "Conferences";
        BindingContext = vmm;
	}
}


public partial class SchedulePageConference : ContentPage
{
    ConferenceViewModel vm;
    ConferenceViewModel VM => vm ??= BindingContext as ConferenceViewModel;
    public SchedulePageConference()
    {
        InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        //if (VM.Schedule.Count == 0)
        // await VM.LoadDataCommand.ExecuteAsync(null);
        VM.serviceCall();
    }
    protected  void OnItemSelected(Object sender, ItemTappedEventArgs e)
    {
       // DisplayAlert("Select", "Please select a conference", "OK");
        var aConf = e.Item as Conference;
        // aConf = VM.serviceCallForAConference();
          Navigation.PushAsync(new ConferenceDetailPage(aConf));
       // VM.serviceCallForAConference(aConf.Id.ToString());
      //  await Task.Delay(500);

      //  Navigation.PushAsync(new LoginPage());
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}

}