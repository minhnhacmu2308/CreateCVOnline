using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreateCVOnline.Models
{
    public class CandidateEditCVModel
    {
        //Activities
        public int numberofAct{ get; set; }
        public string[] Activities { get; set; }
        public string[] timeactivities { get; set; }
        public string[] typeactivities { get; set; }
        public string[] nameactivities { get; set; }
        //Education
        public int numberofEdu { get; set; }
        public string[] Education { get; set; }
        public string[] timeedu { get; set; }
        public string[] typeedu { get; set; }
        public string[] nameedu { get; set; }
        //Job
        public int numberofJob { get; set; }
        public string[] Jobs { get; set; }
        public string[] timejob { get; set; }
        public string[] typejob { get; set; }
        public string[] namejob { get; set; }
        //Skills detail
        public int numberofSkill { get; set; }
        public string[] Skills { get; set; }
        public string[] timeskill { get; set; }
        public string[] typeskill { get; set; }
        public string[] nameskill { get; set; }
    }
}