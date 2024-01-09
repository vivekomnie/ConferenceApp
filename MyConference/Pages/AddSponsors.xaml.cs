using System.Diagnostics;
using MyConference.Models;
using MyConference.ViewModels;
using MyConference.WebServices;
//using static AndroidX.Navigation.Navigator;

namespace MyConference.Pages;

public partial class AddSponsors : ContentPage
{
    AddSponsorViewModel _viewModel;

    public AddSponsors()
	{
		InitializeComponent();
        _viewModel = new AddSponsorViewModel();
        frameImage.IsVisible = false;
       
    }
    async void callWeb()
    {
        RequestSponsor post = new RequestSponsor();

        post.name = nameFiled.Text;
        post.description = descriptionField.Text;
       
        post.logoUrl = new System.Uri(logoUrlField.Text);
        Boolean status = await _viewModel.AddSponsorAsync(Constants.addSponsor, post);
        if (status)
        {
            await DisplayAlert("Sponsor", "Added successfully", "OK");
            navigateToBack();
        }
        else
        {
            await DisplayAlert("Sponsor", "Something went wrong", "OK");
        }
    }
    void AddSponsor_Clicked(System.Object sender, System.EventArgs e)
    {
        Uri uriResult;
        bool result = Uri.TryCreate(logoUrlField.Text, UriKind.Absolute, out uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        if (nameFiled.Text == null)
        {
            DisplayAlert("Select", "Please enter name", "OK");
        }
        else if (descriptionField.Text == null)
        {
            DisplayAlert("Select", "Please enter description", "OK");
        }
        else if (logoUrlField.Text == null)
        {
            DisplayAlert("Select", "Please enter url", "OK");
        }else if (result != true)
        {
            DisplayAlert("Select", "Please enter valid url", "OK");
        }
        else { 
        callWeb();
    }
    }
    void PreviewImage_Clicked(System.Object sender, System.EventArgs e)
    {
        Uri uriResult;
        bool result = Uri.TryCreate(logoUrlField.Text, UriKind.Absolute, out uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

         if (result != true)
        {
            DisplayAlert("Select", "Please enter valid url", "OK");
        }
        else
        {
            frameImage.IsVisible = true;
            previewImage.Source = logoUrlField.Text;
        }
    }
        void navigateToBack()
    {
        Navigation.PopAsync();
    }
}
