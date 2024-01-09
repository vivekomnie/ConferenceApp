using System;
namespace MyConference.Models
{
	public class RequestSession
	{
        public long id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string speakerName { get; set; }

        public string sessionDate { get; set; }

        public string sessionTime { get; set; }
        public string conferenceID { get; set; }
    }
}

