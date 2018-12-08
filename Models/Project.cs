using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalProg_BuffTeks.Models
{
    public class Project
    {
            //PK
            public string ProjectID{ get; set; } //PK
            //First Name
            public string ProjectName { get; set; }

            public string ProjectDescription { get; set; }

            public List<ProjectParticipant> Participants {get; set; }
           // public DateTime DueDate { get; set; } 
            //Last name 
           // public string Client { get; set; }  //FK 
            //public string Members { get; set; }  //FK  - DOES THIS NEED TO BE A LIST???

            

            public override string ToString()
                {
                    string output = $"{this.ProjectName}; {this.ProjectDescription}";
                    return output;
                }
        }
    }

