using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SotsRestApi.Models
{
    public class Semester
    {
        public int ID { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}