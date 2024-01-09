//using Android.Graphics.Drawables;
using MyConference.Models;
using MyConference.ViewModels;
using MyConference.WebServices;
using Refit;

namespace MyConference.Pages;

public partial class ConferenceDetailPage : ContentPage
{
    Conference aConference;
    ConferenceDetailViewModel vm;
    ConferenceDetailViewModel VM => vm ??= BindingContext as ConferenceDetailViewModel;
    public ConferenceDetailPage(Conference aConf)
	{
		InitializeComponent();
      aConference = aConf;


        nameLbl.Text = aConf.Name;
        //addresslbl.Text = aConf.Address;
        //startDateLbl.Text = aConf.StartDateD;
        //endDateLbl.Text = aConf.EndDateD;
        // descriptionLbl.Text = aConf.Description;
        //sess.Text = "";

    }
    protected override void OnAppearing()
    {

        base.OnAppearing();
       
        VM.serviceCall(aConference.Id.ToString());

      
    }
    
    protected async void OnItemSelected(Object sender, ItemTappedEventArgs e)
    {

    }
    }
