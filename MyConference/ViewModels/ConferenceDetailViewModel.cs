using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using MvvmHelpers;
using MyConference.Models;
using MyConference.WebServices;

namespace MyConference.ViewModels
{
	public class ConferenceDetailViewModel: BaseViewModel
    {
        public ObservableRangeCollection<Grouping<string, ConfSession>> _Schedule = new();
        public ObservableRangeCollection<Grouping<string, ConfSession>> Schedule
        {
            get { return _Schedule; }
            set
            {
                _Schedule = value;
                OnPropertyChanged(nameof(Schedule));
            }
        }
        private Conference _aConference;
        public Conference aConference
        {
            get { return _aConference; }
            set
            {
                _aConference = value;
                OnPropertyChanged(nameof(aConference));
            }
        }
        WebService _restService;
        public ConferenceDetailViewModel()
		{
            aConference = new Conference();
            _restService = new WebService();
           

        }
        //public void grouopingSessionList()
        //{
        //    Schedule.Clear();

        //    conferenceList = await _restService.GetConferenceAsync(Constants.getConference);
        //    var sorted = from session in conferenceList
        //                 orderby session.StartDate
        //                 group session by session.StartDateDisplay into sessionGroup
        //                 select new Grouping<string, Conference>(sessionGroup.Key, sessionGroup);

        //    // var sorted = conferenceList.OrderBy(x => x.StartDate)
        //    //               .ToList();
        //    //conferenceList = sorted
        //    Schedule.AddRange(sorted);


        //    Debug.WriteLine("\tInfo{0}vvv...", Schedule.Count);
        //}
        //private ObservableCollection<Conference> _conferenceList1;

       
        public async void serviceCall(String confID)
        {
            //IsLoaderVisible = true;
            String url = Constants.getConference + "/" + confID;
            aConference = await _restService.GetConferenceDetailAsync(url);
            Debug.WriteLine("\tInfo{0}", aConference.Sessions.Count());
            // IsLoaderVisible = false;
            Schedule.Clear();
            var sorted = from session in aConference.Sessions
                         orderby session.SessionTime
                         group session by session.DateDisplay + ", " +session.StartTimeDisplay into sessionGroup
                         select new Grouping<string, ConfSession>(sessionGroup.Key, sessionGroup);

            // var sorted = conferenceList.OrderBy(x => x.StartDate)
            //               .ToList();
            //conferenceList = sorted
            Schedule.AddRange(sorted);
        }

    }
}

