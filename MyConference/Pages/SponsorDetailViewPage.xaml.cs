using MyConference.Models;

namespace MyConference.Pages;

public partial class SponsorDetailViewPage : ContentPage
{
	public SponsorDetailViewPage(Sponsor aSponsor)
	{
		InitializeComponent();
		nameLbl.Text = aSponsor.Name;
		descriptionlbl.Text = aSponsor.Description;
		if (aSponsor.LogoUrl != null){
            logoUrlLbl.Text = aSponsor.LogoUrl.ToString();

            Logoicon.Source = aSponsor.LogoUrl.ToString();
		}
		else
		{
            Logoicon.Source = "";
        
    }
    }
}
