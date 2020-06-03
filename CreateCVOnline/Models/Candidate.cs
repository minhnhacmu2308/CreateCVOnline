using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreateCVOnline.Models
{
    public class Candidate
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Age { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
    }
}