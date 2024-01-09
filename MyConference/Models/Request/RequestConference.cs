using System;
namespace MyConference.Models
{
	public class RequestConference
	{
        public string name { get; set; }


        public string address { get; set; }


        public DateTimeOffset startDate { get; set; }


        public DateTimeOffset endDate { get; set; }


        public string description { get; set; }
    }
}

