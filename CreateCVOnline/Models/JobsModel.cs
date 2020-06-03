using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreateCVOnline.Models
{
    public class JobsModel
    {
        public int ID_Job { get; set; }
        public string JobsDetail { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}