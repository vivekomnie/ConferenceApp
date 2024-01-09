using MyConference.Models;
using MyConference.WebServices;

namespace MyConference.Pages;

public partial class AddConferencePage : ContentPage
{
    WebService _restService;
    public AddConferencePage()
	{
		InitializeComponent();
        _restService = new WebService();
        endDatePicker.Format = "yyyy-MM-dd";
        startDatePicker.Format = "yyyy-MM-dd";
        startDatePicker.MinimumDate = DateTime.Now;
        endDatePicker.MinimumDate = DateTime.Now;
    }
    void Add_Clicked(System.Object sender, System.EventArgs e)
    {
        if (nameEntry.Text == null)
        {
            DisplayAlert("Select", "Please enter name", "OK");
        }
        else if (addressEntry.Text == null)
        {
            DisplayAlert("Select", "Please enter address", "OK");
        }
        else if (startDatePicker.Date > endDatePicker.Date)
             DisplayAlert("Select", "End Date should not be less than the conference start date", "OK");
        else if (descptionEntry.Text == null)
        {
            DisplayAlert("Select", "Please enter description", "OK");
        }
        else
        {
             
            callWeb();
        }
    }
    void navigateToBack()
    {
        Navigation.PopAsync();
    }
    async void callWeb()
    {
        RequestConference post = new RequestConference();

        post.name = nameEntry.Text;
        post.description = descptionEntry.Text;
        post.startDate = startDatePicker.Date;
        post.endDate = endDatePicker.Date;
        post.address = addressEntry.Text;
        Boolean status = await _restService.PostConferenceAsync(Constants.postConference, post);
        if (status)
        {
            await DisplayAlert("Conference", "Added successfully", "OK");
            navigateToBack();
        }
        else
        {
            await DisplayAlert("Conference", "Something went wrong", "OK");
        }
    }
    void OnDateSelected(object sender, DateChangedEventArgs args)
    {
        Recalculate();
    }
    void Recalculate()
    {
        //TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date +
        //    (includeSwitch.IsToggled ? TimeSpan.FromDays(1) : TimeSpan.Zero);

        //resultLabel.Text = String.Format("{0} day{1} between dates",
        //                                    timeSpan.Days, timeSpan.Days == 1 ? "" : "s");
    }
}
