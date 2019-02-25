using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SotsRestApi.Models
{
    public class Course
    {
        [Index(IsUnique = true)]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}