using System;

namespace WebApiVU.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public User Teacher { get; set; }
        public string Group { get; set; }
        public DateTime ClassBegin { get; set; }
        public DateTime ClassEnd { get; set; }
        public Classes Class { get; set; }
    }
}
