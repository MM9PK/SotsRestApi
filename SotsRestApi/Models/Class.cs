using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SotsRestApi.Models
{
    public class Class
    {
        
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ECTSValue { get; set; }
        
        public int TeacherID { get; set; }
        public int SemesterID { get; set; }
        public int CourseID { get; set; }
    }
}