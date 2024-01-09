using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyConference.Models;
using MyConference.WebServices;

namespace MyConference.ViewModels
{
	public class AddSessionPageViewModel: BaseViewModel
    {
        WebService _restService;
        //Conference SelectedConference { get; set; }
        private Conference _SelectedConference;
        public Conference SelectedConference
        {
            get { return _SelectedConference; }
            set
            {
                _SelectedConference = value;
                OnPropertyChanged(nameof(SelectedConference));
            }
        }
        private ObservableCollection<Conference> _conferenceList;
        public ObservableCollection<Conference> conferenceList
        {
            get { return _conferenceList; }
            set
            {
                _conferenceList = value;
                OnPropertyChanged(nameof(conferenceList));
            }
        }

        public AddSessionPageViewModel()
		{

            conferenceList = new ObservableCollection<Conference>();
            _restService = new WebService();
            serviceCall();

        }
        public async void serviceCall()
        {
            conferenceList = await _restService.GetConferenceAsync(Constants.getConference);
           // Debug.WriteLine("\tInfo{0}", conferenceList.Count);
        }

        void OnPickerSelected(object sender, EventArgs e)
        {
            Debug.WriteLine("----viv");
        }
      

    }
}

