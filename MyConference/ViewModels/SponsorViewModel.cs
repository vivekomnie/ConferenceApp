using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using MyConference.Models;
using MyConference.WebServices;
using Newtonsoft.Json;
using Refit;
//using static Android.Gms.Common.Apis.Api;

namespace MyConference.ViewModels
{
    

    public class SponsorViewModel: BaseViewModel
    {
        private bool _isRefreshing = false;
        WebService _restService;
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
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }


      
        public SponsorViewModel()
		{
            sponsorList = new ObservableCollection<Sponsor>();
            _restService = new WebService();
            callService();
        }
        async void callService()
        {
            sponsorList = await _restService.GetSponsorsAsync(Constants.getSponsor);
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    callService();
                    // ConferenceList = await _restService.GetConferenceAsync(Constants.getConference);
                    //ConferenceListView.ItemsSource = conferenceList;
                    //Debug.WriteLine("\tInfo{0}", conferenceList1.Count);
                    IsRefreshing = false;
                });
            }
        }

    }
}

