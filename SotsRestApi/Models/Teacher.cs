using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SotsRestApi.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}