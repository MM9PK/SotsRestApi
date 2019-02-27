using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SotsRestApi.Models
{
    public class Grade
    {
        [Index(IsUnique = true)]
        public int ID { get; set; }
        public float Value { get; set; }

        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }
    }
}