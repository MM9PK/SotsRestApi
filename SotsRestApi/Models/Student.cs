using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SotsRestApi.Models
{
    public class Student
    {
        [Index(IsUnique = true)]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public int AlbumNo { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int ActualSemester { get; set; }
        [Required]
        public int CourseID { get; set; }
    }
}