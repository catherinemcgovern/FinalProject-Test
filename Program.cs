using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using FinalProg_BuffTeks.Models;

namespace FinalProg_BuffTeks
{
    public class Program
    {
        //public static Project TheProject { get; set; }
        
        public static  List<Member> Members  { get; set; }
        public static  List<Client> Clients  { get; set; }
        public static List<Project> Projects { get; set; }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            SeedDatabase();
            //Create Project the project
   
        }
        public static void SeedDatabase()
        {
            //insert ahuimanu database core
             using(var db = new BuffteksContext())
            {
                try
                {
                    //no matter what, delete and then create
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    if(!db.Members.Any())
                    {

                      
                         Guid uniqueID = Guid.NewGuid();
                        //public DbSet<Student> Students { get; set; }    - in DB context
                        //Student.cs
                        List<Member> members = new List<Member>()
                        {
                         new Member() //1
                            {
                                ID = Guid.NewGuid().ToString(),
                                FirstName = "Tina",
                                LastName = "Fey",
                                PhoneNumber = "123-555-1234",
                                Email = "test1@test.com",
                                Role = "Senior"
                            },

                            new Member() //2
                            {
                                ID = Guid.NewGuid().ToString(),
                                FirstName = "Marion",
                                LastName = "McGovern",
                                PhoneNumber = "526-515-4444",
                                Email = "Marion@Woot.com",
                                Role = "Freshman"
                            },

                            new Member()  //3
                            {
                                ID = Guid.NewGuid().ToString(),
                                FirstName = "Vera",
                                LastName = "Herrera",
                                PhoneNumber = "526-515-4444",
                                Email = "Vera@VeraCreates.com",
                                Role = "Freshman"
                            },
                            new Member() //4
                            {
                                ID = Guid.NewGuid().ToString(),
                                FirstName = "Marla",
                                LastName = "Salinger",
                                PhoneNumber = "806-545-2234",
                                Email = "MarlaSinger@wtamu.com",
                                Role = "Sophomore"
                            },

                            new Member()  //5
                            {
                                ID = Guid.NewGuid().ToString(),
                                FirstName = "Dave",
                                LastName = "Kellet",
                                PhoneNumber = "809-241-4433",
                                Email = "DaveKellet@Woot.com",
                                Role = "Junior"
                            },

                            new Member() //6
                            {
                                ID = Guid.NewGuid().ToString(),
                                FirstName = "Maxwell",
                                LastName = "Davenport",
                                PhoneNumber = "663-205-1414",
                                Email = "Maxwell@tothemax.com",
                                Role = "Senior"
                            },


                                                
                        };

                         List<Client> clients = new List<Client>()
                        {
                         new Client()
                            {
                                ID = Guid.NewGuid().ToString(),
                                FirstName = "Ginger",
                                LastName = "Nelson",
                                PhoneNumber = "806-515-3663",
                                Email = "Ginger@amarillo.com",
                                CompanyName = "Woohoo, Inc."
                            },
                        new Client()
                            {
                                ID = Guid.NewGuid().ToString(),
                                FirstName = "Gary",
                                LastName = "Hinkle",
                                PhoneNumber = "926-023-3693",
                                Email = "Gary@canyonrocks.com",
                                CompanyName = "Canyon, Inc."
                            },

                                                
                        };

                        db.Members.AddRange(members);  
                        db.Clients.AddRange(clients);  

                        db.SaveChanges();          

                          Projects = new List<Project>();
                        Projects.Add (new Project () {ProjectID = Guid.NewGuid().ToString(),
                        ProjectName = "Neato-Taquito Project",
                        ProjectDescription = "Taquitos rule lunch and now they will rule the web",
                        Participants = new List<ProjectParticipant>()
                        });

                        Projects.Add (new Project () {ProjectID = Guid.NewGuid().ToString(),
                        ProjectName = "Awesome Possum Project",
                        ProjectDescription = "I can has Possum-ness. Possums are the new cats of the interwebs",
                        Participants = new List<ProjectParticipant>()
                        });

                        //take the first project and add the firstclient into that project
                        Projects[0].Participants.Add(Clients[0]);
                        Projects[1].Participants.Add(Clients[1]);
                        //Take the first project and add in the firstthree members in the list and add them to the project
                        Projects[0].Participants.Add(Members[0]);
                        Projects[0].Participants.Add(Members[1]);
                        Projects[0].Participants.Add(Members[2]);

                        //Take second project and add the next three members into that list
                        Projects[1].Participants.Add(Members[3]);
                        Projects[1].Participants.Add(Members[4]);
                        Projects[1].Participants.Add(Members[5]);

                        PrintProjectAllParticipants();   


                                                         

                    }
                    else
                    {
                        var members = db.Members.ToList();
                        foreach(Member s in members)
                        {
                            Console.WriteLine(s);
                        }
                    }


                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

               
            }
     //end insert ahuimanu database core
    }


    public static void PrintProjectAllParticipants()
    {
        foreach(Project p in Projects)
        {
            foreach(ProjectParticipant party in p.Participants)
            {
                Console.WriteLine(party);
            }
        }
    }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
