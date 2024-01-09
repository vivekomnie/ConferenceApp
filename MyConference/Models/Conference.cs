using System;


namespace MyConference.Models
{
	public class Conference
	{
		
           
            public bool IsActive { get; set; }

          
            public bool IsDeleted { get; set; }

           
            public long CreatedBy { get; set; }

           
            public long Id { get; set; }
        public ConfSession[] Sessions { get; set; }


        public string Name { get; set; }

            
            public string Address { get; set; }

           
            public DateTime StartDate { get; set; }

            
            public DateTime EndDate { get; set; }

           
            public string Description { get; set; }
        public string StartDateDisplay => $"Start Date: {StartDate:dd} {StartDate:MMM} {StartDate:yyyy}";
        public string DayDisplay => $"{StartDate:MMM} {StartDate:d}";
        public string EndDateDisplay => $"End Date: {EndDate:dd} {EndDate:MMM} {EndDate:yyyy}";
        public string StartDateD => $"{StartDate:dd} {StartDate:MMM} {StartDate:yyyy}";
        public string EndDateD => $"{EndDate:dd} {EndDate:MMM} {EndDate:yyyy}";


    }

}

