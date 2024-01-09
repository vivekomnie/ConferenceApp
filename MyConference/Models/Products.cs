using System;
using System.Collections;

namespace MyConference.Models
{
	public class Products
	{
		

        public string Title { get; set; }
        public string Category { get; set; }
        public IList ServiceCall { get; internal set; }
    }
}

