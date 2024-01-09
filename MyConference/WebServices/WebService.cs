using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
//using Java.Net;
using MyConference.Models;
using Newtonsoft.Json;
//using static Android.Gms.Common.Apis.Api;
//using static Android.Gms.Common.Apis.Api;

namespace MyConference.WebServices
{
    public static class Constants
    {
        public const string Username = "username";
        public const string Password = "userpassword";
        public const string EndPoint = "http://121.243.75.240/msconf-api/";
        public const string ProductEndpoint = "https://fakestoreapi.com/products";
        public const string getConference = EndPoint + "api/Conference";
        public const string postConference = EndPoint + "api/Conference";
        public const string addSession = EndPoint + "api/Session";
        public const string getSession = EndPoint + "api/Session";
        public const string getSponsor = EndPoint + "api/Sponsor";
        public const string addSponsor =  EndPoint + "api/Sponsor";

    }

    public class WebService
	{
        HttpClient _client;
        public WebService()
		{
            _client = new HttpClient();
            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

        }
        public async Task<List<Products>> GetProductAsync(string uri)
        {
            List<Products> repositories = null;
            try
            {
               
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    repositories = JsonConvert.DeserializeObject<List<Products>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return repositories;
        }

        public async Task<Conference> GetConferenceDetailAsync(string uri)
        {
            Conference aConference = null;
            try
            {
                
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    aConference = JsonConvert.DeserializeObject<Conference>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return aConference;
        }
        public async Task<ObservableCollection<Conference>> GetConferenceAsync(string uri)
        {
            ObservableCollection<Conference> repositories = null;
            try
            {
                
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    repositories = JsonConvert.DeserializeObject<ObservableCollection<Conference>>(content);
                    repositories.OrderByDescending(x => x.StartDate)
                                   .ToList();
                }

                else
                {
                  var  conferenceList = new ObservableCollection<Conference>();
                    repositories = conferenceList;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
                return repositories;
            }

            return repositories;
        }
        public async Task<Boolean> PostConferenceAsync(string uri, RequestConference postRequest)
        {
            Boolean conferencedAdded = false;
            
            var requestJson = JsonConvert.SerializeObject(postRequest);
            Debug.WriteLine("requestJson", requestJson);
            //string jsonData = @"{""name"" : ""myusername"", ""address"" : ""myadd"",""startDate"" : ""myusername"", ""endDate"" : ""enddate1"",""description"":""des""}";
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
          
            try
            {
                HttpResponseMessage response = await _client.PostAsync(uri, content); ;
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("result", result);
                    String repositories = JsonConvert.DeserializeObject<String>(result);
                    Debug.WriteLine("resultrepositories", repositories);
                    // if(result)
                    conferencedAdded = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return conferencedAdded;
        }
        public async Task<ObservableCollection<Sponsor>> GetSponsorsAsync(string uri)
        {
            ObservableCollection<Sponsor> sponsorList1 = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    sponsorList1 = JsonConvert.DeserializeObject<ObservableCollection<Sponsor>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return sponsorList1;
        }
        public async Task<Boolean> AddSessionAsync(string uri, RequestSession postRequest)
        {
            Boolean conferencedAdded = false;

            var requestJson = JsonConvert.SerializeObject(postRequest);
            Debug.WriteLine("requestJson", requestJson);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _client.PostAsync(uri, content); ;
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("result", result);
                    String repositories = JsonConvert.DeserializeObject<String>(result);
                    Debug.WriteLine("resultrepositories", repositories);
                    // if(result)
                    conferencedAdded = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return conferencedAdded;
        }
    }
}

