using System;
using System.Collections.ObjectModel;
using MyConference.Models;

namespace MyConference.ViewModels
{
    class CityViewModel
    {
        public IList<City> CityList { get; set; }

        public CityViewModel()
	{


        CityList = new ObservableCollection<City>();
			CityList.Add(new City {
                CityId=1,
                CityName="Conference 1"});
            CityList.Add(new City
            {
                CityId = 2,
                CityName = "Conference 2"
            });
            CityList.Add(new City
            {
                CityId = 3,
                CityName = "Conference 3"
            });
            CityList.Add(new City
            {
                CityId = 4,
                CityName = "Conference 4"
            });
            CityList.Add(new City
            {
                CityId = 5,
                CityName = "Conference 5"
            });



        }
}
}

