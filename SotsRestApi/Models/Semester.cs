using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SotsRestApi.Models
{
    public class Semester
    {
        [Index(IsUnique = true)]
        public int ID { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}