using System;
//using Android.Hardware.Camera2.Params;
using Newtonsoft.Json;

namespace MyConference.Models
{
	public class Sponsor
	{
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Uri LogoUrl { get; set; }
        public string DisplayUrl => $"{LogoUrl}";

    }
}

