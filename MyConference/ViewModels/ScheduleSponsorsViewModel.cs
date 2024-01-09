using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Jeffsum;
using MvvmHelpers;
using MyConference.Models;
using MyConference.WebServices;
using static Jeffsum.Goldblum;

namespace MyConference.ViewModels;


public partial class ScheduleSponsorsViewModel : BaseViewModel
{    
    public int Day { get; set; }
  //  public ObservableRangeCollection<Grouping<string, Sponsor>> _Schedule = new();
    Random random = new ();
    WebService _restService;
   // public ObservableCollection<Sponsor> sponsorList = new ObservableCollection<Sponsor>();

    private ObservableCollection<Sponsor> _sponsorList;
    public ObservableCollection<Sponsor> sponsorList
    {
        get { return _sponsorList; }
        set
        {
            _sponsorList = value;
            OnPropertyChanged(nameof(sponsorList));
        }
    }
    // private ObservableCollection<Conference> _conferenceList1;

    //public ObservableRangeCollection<Grouping<string, Sponsor>> Schedule
    //{
    //    get { return _Schedule; }
    //    set
    //    {
    //        _Schedule = value;
    //        OnPropertyChanged(nameof(Schedule));
    //    }
    //}

    public ScheduleSponsorsViewModel()
    {
       // conferenceList1 = new ObservableCollection<Conference>();
        _restService = new WebService();
        //serviceCall();
    }
    public async void serviceCall()
    {
        // IsLoaderVisible = true;
       // Schedule.Clear();

        sponsorList = await _restService.GetSponsorsAsync(Constants.getSponsor);
        //var sorted = from session in sponsorList
        //             orderby session.Name
        //             group session by session.Name into sessionGroup
        //             select new Grouping<string, Sponsor>(sessionGroup.Key, sessionGroup);

        
       // Schedule.AddRange(sorted);


      //  Debug.WriteLine("\tInfo{0}vvv...", Schedule.Count);
       // IsLoaderVisible = false;
    }
  

    //[RelayCommand]
    // Task LoadDataAsync()
    //{
    //    var sorted = from session in sponsorList
    //                 orderby session.Name
    //                 group session by session.Name into sessionGroup
    //                 select new Grouping<string, Sponsor>(sessionGroup.Key, sessionGroup);

    //    Schedule.AddRange(sorted);

    //    return Task.CompletedTask;

       
    //}



}
