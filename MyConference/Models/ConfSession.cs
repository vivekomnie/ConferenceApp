using System;
namespace MyConference.Models
{
	public class ConfSession
	{
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public string ConferenceName { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SpeakerName { get; set; }

        public DateTimeOffset SessionDate { get; set; }

        public DateTimeOffset SessionTime { get; set; }

        public long ConferenceId { get; set; }
        public string StartTimeDisplay => $"{SessionTime:hh:mm tt}";
        public string DateDisplay => $"{SessionDate:dd} {SessionDate:MMM} {SessionDate:yyyy}";

    }
}

