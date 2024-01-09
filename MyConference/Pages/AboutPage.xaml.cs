
//using Android.Gms.Common;
using MyConference.ViewModels;
//using static Java.Util.Jar.Attributes;

namespace MyConference.Pages;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        NavigationPage.SetBackButtonTitle(this, "ok");
        
    }
    protected override void OnAppearing()
    {

        updateUI();
        //var myValue = Preferences.Get("userid", "default_value");
        //if (myValue != "default_value")
        //{
        //    loginButton.Text = "User Detail";
        //    addConference.IsVisible = true;
        //    addSession.IsVisible = true;
        //    addSponsor.IsVisible = true;
        //    logout.IsVisible = true;
        //}

        //else
        //{
        //    loginButton.Text = "Login";
        //    addConference.IsVisible = false;
        //    addSession.IsVisible = false;
        //    addSponsor.IsVisible = false;
        //    logout.IsVisible = false;
        //}
        // loginButton.IsVisible = false;
        base.OnAppearing();
    }
    void updateUI()
    {
        var myValue = Preferences.Get("userid", "default_value");

        loginButton.Text = (myValue != "default_value") ? "User Detail" : "Login";
        addConference.IsVisible = myValue != "default_value";
        addSession.IsVisible = myValue != "default_value";
        addSponsor.IsVisible = myValue != "default_value";
        logout.IsVisible = false;
    }
    void LoginButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }

    void Manage_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new RegistartionPage());
        Console.WriteLine("Vivekl");
    }

    void AddConference_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new AddConferencePage());
        Console.WriteLine("Vivekl");
    }
    void AddSession_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new AddSessionPage());
        Console.WriteLine("Vivekl");
    }
    void AddSponsor_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new AddSponsors());
        Console.WriteLine("Vivekl");
    }
    void Logout_Clicked(System.Object sender, System.EventArgs e)
    {
        Preferences.Set("userid", null);
        Preferences.Set("password", null);
        updateUI();
    }
}