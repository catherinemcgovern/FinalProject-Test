using System;
using System.Collections.Generic;

namespace FinalProg_BuffTeks.Models
{
    public class Client : ProjectParticipant
        {
        public string CompanyName { get; set; }
        
        public Project TheProject { get; set; }  

        public string ProjectID { get; set; } //Project - FK   

        public override string ToString() => $"{this.ID}; {this.FirstName}; {this.PhoneNumber}; {this.Email};";
    }

    
}

