using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Jeffsum;
using MvvmHelpers;
using MyConference.Models;
using MyConference.WebServices;
using static Jeffsum.Goldblum;

namespace MyConference.ViewModels;


public partial class ConferenceViewModel : BaseViewModel
{    
    public int Day { get; set; }
    public ObservableRangeCollection<Grouping<string, Conference>> _Schedule = new();
    Random random = new ();
    WebService _restService;
    public ObservableCollection<Conference> conferenceList = new ObservableCollection<Conference>();


    public ObservableRangeCollection<Grouping<string, Conference>> Schedule
    {
        get { return _Schedule; }
        set
        {
            _Schedule = value;
            OnPropertyChanged(nameof(Schedule));
        }
    }

    public ConferenceViewModel()
    {
        _restService = new WebService();
    }
    public async void serviceCall()
    {
        // IsLoaderVisible = true;

        conferenceList = await _restService.GetConferenceAsync(Constants.getConference);
        var sorted = from session in conferenceList
                     orderby session.StartDate
                     group session by session.StartDateDisplay into sessionGroup
                     select new Grouping<string, Conference>(sessionGroup.Key, sessionGroup);
        //var ss = sorted.Reverse<key>
        // var sorted = conferenceList.OrderBy(x => x.StartDate)
        //               .ToList();
        //conferenceList = sorted
        Schedule.Clear();

        Schedule.AddRange(sorted.Reverse());


        Debug.WriteLine("\tInfo{0}vvv...", Schedule.Count);
       // IsLoaderVisible = false;
    }
    




}
