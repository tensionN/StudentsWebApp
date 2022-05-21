using System;

namespace lab7.Models
{
    public class Student
    {
        public Guid ID { get; set; }
        public string Lastname { get; set; }
        public string Name { get; set; }
        public int GroupNumber { get; set; }
        public string NameSpecialty { get; set; }
        public float AverageScore { get; set; }

    }
}
