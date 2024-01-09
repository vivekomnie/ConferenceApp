using System;
using Newtonsoft.Json;

namespace MyConference.Models
{
	public class SessionObject
	{
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SpeakerName { get; set; }

        public DateTimeOffset SessionDate { get; set; }

        public DateTimeOffset SessionTime { get; set; }
    }
}

