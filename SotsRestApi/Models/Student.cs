using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotsRestApi.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int AlbumNo { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int ActualSemester { get; set; }
        [Required]
        public int CourseID { get; set; }
    }
}