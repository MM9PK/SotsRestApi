using System;
using System.Collections.Generic;

namespace SotsRestApi.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AlbumNo { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int ActualSemester { get; set; }

        public int CourseID { get; set; }
    }
}