using System.Diagnostics;

namespace MyConference.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        //emailEntry.Text = "username";
       // passEntry.Text = "userpassword";
        var myValue = Preferences.Get("userid", "default_value");
        if (myValue == "username")
        {
            signButton.IsVisible = false;
            logoutButton.IsVisible = true;
            emailEntry.Text = "username";
             passEntry.Text = "userpassword";
            emailEntry.IsReadOnly = true;
            passEntry.IsReadOnly = true;
        }

        else
        {
            signButton.IsVisible = true;
            logoutButton.IsVisible = false;
            emailEntry.IsReadOnly = false;
            passEntry.IsReadOnly = false;
        }
        Debug.WriteLine("\tERROR {0}", myValue);
       
    }

    void LoginClicked(System.Object sender, System.EventArgs e)
    {
        
        if (emailEntry.Text == null)
        {
            DisplayAlert("Select", "Please enter username", "OK");
        }
        else if (passEntry.Text == null)
        {
            DisplayAlert("Select", "Please enter password", "OK");
        }
        else
        {
            if (emailEntry.Text.ToLower() == "username")
            {
                Preferences.Set("userid", emailEntry.Text.ToLower());
                Preferences.Set("password", passEntry.Text);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Select", "Username or password incorrect.", "OK");
            }

        }

    }
    void LogoutClicked(System.Object sender, System.EventArgs e)
    {
        Preferences.Set("userid", null);
        Preferences.Set("password", null);
        Navigation.PopAsync();
    }

        void ContentPage_NavigatedFrom(System.Object sender, Microsoft.Maui.Controls.NavigatedFromEventArgs e)
    {
    }
}
