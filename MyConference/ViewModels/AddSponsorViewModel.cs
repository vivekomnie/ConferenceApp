using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using MyConference.Models;
using MyConference.WebServices;
using Newtonsoft.Json;

namespace MyConference.ViewModels
{
	public class AddSponsorViewModel
	{
        HttpClient _client;

        public AddSponsorViewModel()
		{
            _client = new HttpClient();
            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }
        public async Task<Boolean> AddSponsorAsync(string uri, RequestSponsor postRequest)
        {
            Boolean sponsorAdded = false;

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
                    sponsorAdded = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return sponsorAdded;
        }
    }
}

