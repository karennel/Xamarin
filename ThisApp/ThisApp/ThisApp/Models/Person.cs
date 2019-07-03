using System;
using System.Collections.Generic;
using System.Text;

namespace ThisApp.Models
{
    public class Person
    {
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string FullName {
			get { return FirstName + " " + LastName; }
			set { } }
    }
}
