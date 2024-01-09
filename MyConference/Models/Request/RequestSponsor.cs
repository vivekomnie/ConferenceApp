using System;
namespace MyConference.Models
{
	public class RequestSponsor
	{
        public long id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public Uri logoUrl { get; set; }
    }
}

