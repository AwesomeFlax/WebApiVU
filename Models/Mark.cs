using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVU.Models
{
	public class Mark
	{
		public int Id { get; set; }
		public User Teacher { get; set; }
		public User Student { get; set; }
		public Classes Class { get; set; }
		public DateTime DateTime { get; set; }
		public double Result { get; set; }
		public int Semester { get; set; }
		public int Atempt { get; set; }
	}
}
