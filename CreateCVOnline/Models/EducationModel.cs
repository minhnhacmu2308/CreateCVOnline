using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreateCVOnline.Models
{
    public class EducationModel
    {
        public int IDEdu { get; set; }
        public string EducationDetail { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}