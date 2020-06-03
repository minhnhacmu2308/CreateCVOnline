using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreateCVOnline.Models
{
    public class CVModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
        public int ID_Jobs { get; set; }
        public string Goal { get; set; }
        public int ID_Education { get; set; }
        public int ID_Skills { get; set; }
        public int ID_Activities { get; set; }
        public string Image { get; set; }
    }
}