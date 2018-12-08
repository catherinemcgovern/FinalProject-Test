using System;
using System.Collections.Generic;

namespace FinalProg_BuffTeks.Models
{

        public class Member : ProjectParticipant
        {
            //PK
            //Name
            public string Role { get; set; }
            //public string Project { get; set; }  DOES THIS NEED TO BE A LIST TOO?
        
            //role
         public override string ToString() => $"{this.ID}; {this.FirstName}; {this.LastName}; {this.PhoneNumber}; {this.Role}";
            
        }
    }
