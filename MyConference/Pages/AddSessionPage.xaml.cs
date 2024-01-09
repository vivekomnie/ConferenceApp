//using Java.Net;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MyConference.Models;
using MyConference.ViewModels;
using MyConference.WebServices;
using Newtonsoft.Json;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyConference.Pages;

public partial class AddSessionPage : ContentPage
{
    AddSessionPageViewModel vm;
    AddSessionPageViewModel VM => vm ??= BindingContext as AddSessionPageViewModel;
    WebService _restService;
    //private Conference selectedConf;

    public AddSessionPage()
	{
		InitializeComponent();
       // datePicker.MinimumDate = DateTime.Now;
        _restService = new WebService();
        //selectedConf = new selectedConf();
       // BindingContext = addSessionPageViewModel;
       // datePicker.Format = "yyyy-MM-dd";

    }
    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
           // selectedConf = (Conference)picker.ItemsSource[selectedIndex];
//Debug.WriteLine("----viv111", Confe.StartDate.Date);
           // Debug.WriteLine("----viv", Confe.StartDate.time);
           // datePicker1.MinimumDate = selectedConf.StartDate.Date;
           // datePicker1.MaximumDate = selectedConf.EndDate.Date;
            //  DisplayAlert("Select", Confe.StartDate.DateTime.ToString(), "OK");

            //  nameField.Text = (string)picker.ItemsSource[selectedIndex];
        }
    }
    void OnPickerSelected(object sender, EventArgs e)
    {
        Debug.WriteLine("----viv");
    }
    protected override async void OnAppearing()
    {
       
       // ObservableCollection<Conference> conferenceList = await _restService.GetConferenceAsync(Constants.getConference);

      //  ConferencePicker.ItemsSource = conferenceList;
        base.OnAppearing();
    }
    async void Add_Clicked(System.Object sender, System.EventArgs e)
    {
       
        if (ConferencePicker.SelectedItem == null)
            {
            await DisplayAlert("Select", "Please select a conference ", "OK");

            
        }
        else if (nameField.Text == null)
        {
            await DisplayAlert("Select", "Please enater name ", "OK");


        }
        else if (descriptionField.Text == null)
        {
            await DisplayAlert("Select", "Please enter descrption ", "OK");


        }
        else if (speakerField.Text == null)
        {
            await DisplayAlert("Select", "Please enter speaker name ", "OK");


        }
        else if (VM.SelectedConference.EndDate < datePicker1.Date)
            await DisplayAlert("Select", "Date should not be grater than the conference end date - " + VM.SelectedConference.EndDateD, "OK");
        else
        {
           
             callWeb();
        }

    }
    async void callWeb()
    {


        RequestSession post = new RequestSession();

        post.name = nameField.Text;
        post.description = descriptionField.Text;
        post.sessionDate = datePicker1.Date.ToString("yyyy-MM-dd");
        post.sessionTime = timePicker.Time.ToString();
        post.speakerName = speakerField.Text;

        post.conferenceID = VM.SelectedConference.Id.ToString();
        Boolean status = await _restService.AddSessionAsync(Constants.addSession, post);
        if (status)
        {
            await DisplayAlert("Session", "Added successfully", "OK");
            navigateToBack();
        }
        else
        {
            await DisplayAlert("Session", "Something went wrong", "OK");
        }
    }
    void OnDateSelected(object sender, DateChangedEventArgs args)
    {
        //nameField.Text = args.NewDate;
    }
    void OnTimeSelected(object sender, DateChangedEventArgs args)
    {
       
    }
    void navigateToBack()
    {
        Navigation.PopAsync();
    }
}

