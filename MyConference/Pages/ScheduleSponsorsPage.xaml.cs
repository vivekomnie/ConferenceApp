using Microsoft.Maui.Controls;
using MyConference.Models;
using MyConference.ViewModels;

namespace MyConference.Pages;

public partial class ScheduleSponsors1Page : ScheduleSponsorsPage
{
	public ScheduleSponsors1Page(ScheduleSponsorsViewModel vmm) : base()
	{
        vmm.Day = 1;
        Title = "Sponsors";
        BindingContext = vmm;
	}
}


public partial class ScheduleSponsorsPage : ContentPage
{
	ScheduleSponsorsViewModel vm;
    ScheduleSponsorsViewModel VM => vm ??= BindingContext as ScheduleSponsorsViewModel;
    public ScheduleSponsorsPage()
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
    protected async void OnItemSelected(Object sender, ItemTappedEventArgs e)
    {
        if (sender is ListView lv) lv.SelectedItem = null;

        //  var aSpon = e.Item as Sponsor;
        //  await Navigation.PushAsync(new SponsorDetailViewPage(aSpon));
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}

}