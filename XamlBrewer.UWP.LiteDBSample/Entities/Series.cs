using LiteDB;

namespace XamlBrewer.UWP.LiteDBSample.Entities
{
    public class Series
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Creator { get; set; }

        public string Description { get; set; }

        public string[] Genres { get; set; }

        public Season[] Seasons { get; set; }

        [BsonRef("actors")]
        public Actor[] Cast { get; set; }

        public static Series[] SampleData
        {
            get
            {
                return new Series[]
                {
                    new Series
                    {
                        Name = "Altered Carbon",
                        Creator = "Laeta Kalogridis",
                        Seasons = new Season[]
                        {
                            new Season
                            {
                                Year = 2018,
                                Episodes = new Episode[]
                                {
                                    new Episode
                                    {
                                    Sequence = 1,
                                    Title = "Out of the Past",
                                    Description = "Waking up in a new body 250 years after his death, Takeshi Kovacs discovers he's been resurrected to help a titan of industry solve his own murder."
                                    },
                                    new Episode
                                    {
                                    Sequence = 2,
                                    Title = "Fallen Angel",
                                    Description = "While Kovacs tracks down a man who sent Bancroft a death threat, Lt. Ortega bends the rules to keep tabs on his whereabouts."
                                    },
                                    new Episode
                                    {
                                    Sequence = 3,
                                    Title = "In a Lonely Place",
                                    Description = "Kovacs recruits an unlikely partner to watch his back during a banquet at the Bancroft home, where Ortega oversees the night's grisly entertainment."
                                    },
                                    new Episode
                                    {
                                    Sequence = 4,
                                    Title = "Force of Evil",
                                    Description = "Tortured by his captor, Kovacs taps into his Envoy training to survive. Ortega springs a surprise on her family for Día de los Muertos."
                                    },
                                    new Episode
                                    {
                                    Sequence = 5,
                                    Title = "The Wrong Man",
                                    Description = "After learning his sleeve's identity, Kovacs demands the full story from Ortega. A tip from Poe leads to a major breakthrough in the Bancroft case."
                                    },
                                    new Episode
                                    {
                                    Sequence = 6,
                                    Title = "Man with My Face",
                                    Description = "With Ortega's fate hanging in the balance, Kovacs drops a bombshell on the Bancrofts. Later, he comes face to face with an unsettling opponent."
                                    },
                                    new Episode
                                    {
                                    Sequence = 7,
                                    Title = "Nora Inu",
                                    Description = "As Kovacs reconnects with a figure from his past, his tangled history with the Protectorate, the Uprising and Quell plays out in flashbacks."
                                    },
                                    new Episode
                                    {
                                    Sequence = 8,
                                    Title = "Clash by Night",
                                    Description = "His world rocked, Kovacs requests a dipper to help him sew up the Bancroft case quickly. Ortega races to identify the mystery woman from Fight Drome."
                                    },
                                    new Episode
                                    {
                                    Sequence = 9,
                                    Title = "Rage in Heaven",
                                    Description = "After a devastating rampage, Kovacs and his allies hatch a bold -- and very risky -- scheme to infiltrate Head in the Clouds."
                                    },
                                    new Episode
                                    {
                                    Sequence = 10,
                                    Title = "The Killers",
                                    Description = "As a cornered Kovacs braces for a final showdown in the sky, a new hero emerges and more buried secrets come to light."
                                    }
                                }
                            },
                            new Season
                            {
                                Year = 2020,
                                Episodes = new Episode[]
                                {
                                    new Episode
                                    {
                                    Sequence = 1,
                                    Title = "Phantom Lady",
                                    Description = "Thirty years after the Bancroft case, a Meth tracks down Kovacs to offer him a job, a high-tech sleeve and a chance to see Quellcrist Falconer again."
                                    },
                                    new Episode
                                    {
                                    Sequence = 2,
                                    Title = "Payment Deferred",
                                    Description = "As Col. Carrera takes charge of the murder investigation, Kovacs sets out to find Axley's bounty hunter, and Poe's memory glitches worsen."
                                    },
                                    new Episode
                                    {
                                    Sequence = 3,
                                    Title = "Nightmare Alley",
                                    Description = "Kovacs contends with ghosts from his past as he's tortured by Carrera. Poe seeks help from a fellow AI. Trepp gets a lead on the man she's after."
                                    },
                                    new Episode
                                    {
                                    Sequence = 4,
                                    Title = "Shadow of a Doubt",
                                    Description = "Shadow of a Doubt"
                                    },
                                    new Episode
                                    {
                                    Sequence = 5,
                                    Title = "I Wake Up Screaming",
                                    Description = "Carrera sends his secret weapon on a deadly mission. Kovacs and Trepp smuggle Quell out of the city. Poe takes a risky trip into virtual reality."
                                    },
                                    new Episode
                                    {
                                    Sequence = 6,
                                    Title = "Bury Me Dead",
                                    Description = "As Quell reconnects to her past at Stronghold, she leads the clone into an underground chamber teeming with secrets. Gov. Harlan shows her true colors."
                                    },
                                    new Episode
                                    {
                                    Sequence = 7,
                                    Title = "Experiment Perilous",
                                    Description = "When Quell's sleeve begins to shut down, Poe and Ms. Dig send her into VR, where Kovacs finally learns the truth about her deadly rampages."
                                    },
                                    new Episode
                                    {
                                    Sequence = 8,
                                    Title = "Broken Angels",
                                    Description = "With the fate of the whole planet on the line, Kovacs, Quell and team race to find Konrad Harlan and stop a catastrophic blast of Angelfire."
                                    }
                                }
                            }
                        }
                    },
                    new Series
                    {
                        Name = "Formula1: Drive to survive",
                        Creator = "Netflix",
                        Seasons = new Season[]
                        {
                            new Season
                            {
                                Year = 2019,
                                Episodes = new Episode[]
                                {
                                    new Episode
                                    {
                                    Sequence = 1,
                                    Title = "All to Play For",
                                    Description = "Driver Daniel Ricciardo looks to make a statement on the track while the teams prepare for the first race of the season at the Australian Grand Prix."
                                    },
                                 new Episode
                                    {
                                    Sequence = 2,
                                    Title = "The King of Spain",
                                    Description = "Team McLaren aims to turn things around as its driver Fernando Alonso faces Renault's Carlos Sainz Jr. at the Spanish Grand Prix in Barcelona."
                                    },
                                 new Episode
                                    {
                                    Sequence = 3,
                                    Title = "Redemption",
                                    Description = "At the prestigious Monaco Grand Prix, Ricciardo feels pressured by an upstart. Also, the men and women of Williams Racing fight to remain relevant."
                                    },
                                 new Episode
                                    {
                                    Sequence = 4,
                                    Title = "The Art of War",
                                    Description = "The troubled offtrack relationship between Red Bull and Renault hits a new low. Meanwhile, a top Formula 1 driver makes a shocking move."
                                    },
                            new Episode
                                    {
                                    Sequence = 5,
                                    Title = "Trouble at the Top",
                                    Description = "A team's financial backing doesn't always translate into victories. See: McLaren. Also, the principal and co-owner of Force India faces legal issues."
                                    },
                                 new Episode
                                    {
                                    Sequence = 6,
                                    Title = "All or Nothing",
                                    Description = "When Force India is bought by a group led by Lawrence Stroll, the team's two drivers worry Stroll's son, Lance, may take one of their spots."
                                    },
                                 new Episode
                                    {
                                    Sequence = 7,
                                    Title = "Keeping Your Head",
                                    Description = "Perhaps trying too hard, Haas F1 Team driver Romain Grosjean struggles with confidence and nerves at the famed French Grand Prix."
                                    },
                                 new Episode
                                    {
                                    Sequence = 8,
                                    Title = "The Next Generation",
                                    Description = "Sauber driver Charles Leclerc hopes to achieve something his late godfather Jules Bianchi never did: race for Ferrari."
                                    },
                                 new Episode
                                    {
                                    Sequence = 9,
                                    Title = "Stars and Stripes",
                                    Description = "The bitter rivalry between Renault and Haas heats up, and the mid-tier teams vie for bragging rights at the United States Grand Prix in Austin, Texas."
                                    },
                                 new Episode
                                    {
                                    Sequence = 10,
                                    Title = "Crossing the Line",
                                    Description = "Drivers - both legends and upstarts - focus on ending the year on a high note as the teams prepare for the season's final race at Abu Dhabi."
                                    }
                                }
                            },
                           new Season
                            {
                                Year = 2020,
                                Episodes = new Episode[]
                                {
                                    new Episode
                                    {
                                    Sequence = 1,
                                    Title = "Lights Out",
                                    Description = "Another Formula 1 season kicks off at the Australian Grand Prix as 10 racing teams vie for the podium."
                                    },
                                 new Episode
                                    {
                                    Sequence = 2,
                                    Title = "Boiling Point",
                                    Description = "As mediocrity becomes the norm for Team Haas, frustration over the poor performances threaten to tear the group apart from within."
                                    },
                                 new Episode
                                    {
                                    Sequence = 3,
                                    Title = "Dogfight",
                                    Description = "Eager to return their teams to glory, Renault's Daniel Ricciardo and McLaren's Carlos Sainz Jr. vow to prove themselves on the track."
                                    },
                                 new Episode
                                    {
                                    Sequence = 4,
                                    Title = "Dark Days",
                                    Description = "Lewis Hamilton and the Mercedes team - long dominant in Formula 1 - face a true test of mettle on a rain-soaked track at the German Grand Prix."
                                    },
                            new Episode
                                    {
                                    Sequence = 5,
                                    Title = "Great Expectations",
                                    Description = "Red Bull rivals Max Verstappen and Pierre Gasly race in Monaco, Montreal and Austria, where one driver shines and the other struggles."
                                    },
                                 new Episode
                                    {
                                    Sequence = 6,
                                    Title = " Raging Bulls",
                                    Description = "Alex Albon, the newest driver for Team Red Bull, strives to accomplish what his predecessor couldn't. Also, tragedy strikes at the Belgian Grand Prix."
                                    },
                                 new Episode
                                    {
                                    Sequence = 7,
                                    Title = "Seeing Red",
                                    Description = "Few - if any - teams have a history that can match Ferrari's. But not even the Prancing Horse is immune to a little interdriver drama."
                                    },
                                 new Episode
                                    {
                                    Sequence = 8,
                                    Title = "Musical Chairs",
                                    Description = "For Formula 1 drivers like Nico Hülkenberg, holding on to a job can feel like a game of musical chairs. Will the music stop at the German Grand Prix?"
                                    },
                                 new Episode
                                    {
                                    Sequence = 9,
                                    Title = "Blood, Sweat & Tears",
                                    Description = "While many believe Williams's best years are long gone, deputy team principal Claire Williams sees a bright future with rookie driver George Russell."
                                    },
                                 new Episode
                                    {
                                    Sequence = 10,
                                    Title = "Checkered Flag",
                                    Description = "As the 2019 season winds down, upstart drivers - including Albon, Gasly and Sainz - compete for one last chance at a podium finish."
                                    }
                                }
                            }
                        }
                    },
                    new Series
                    {
                        Name = "Rick and Morty",
                        Creator = "Adult Swim",
                        Seasons = new Season []
                        {
                            new Season
                            {
                                Year = 2019,
                                Episodes = new Episode[]
                                {
                                    new Episode
                                    {
                                        Sequence = 1,
                                        Title = "Edge of Tomorty: Rick Die Rickpeat",
                                        Description = "Wubba lubba dub dub"
                                    },
                                    new Episode
                                    {
                                        Sequence = 2,
                                        Title = "The Old Man and the Seat",
                                        Description = "Wubba lubba dub dub"
                                    },
                                    new Episode
                                    {
                                        Sequence = 3,
                                        Title = "One Crew over the Crewcoo's Morty",
                                        Description = "Wubba lubba dub dub ... fight"
                                    },
                                    new Episode
                                    {
                                        Sequence = 4,
                                        Title = "Claw and Hoarder: Special Ricktim's Morty",
                                        Description = "Wubba lubba dub dub"
                                    },
                                    new Episode
                                    {
                                        Sequence = 5,
                                        Title = "Rattlestar Ricklactica",
                                        Description = "Wubba lubba dub dub"
                                    }
                                }
                            }
                        }
                    }
                };
            }
        }
    }

    public class Season
    {
        public int Year { get; set; }

        public Episode[] Episodes { get; set; }
    }

    public class Episode
    {
        public int Sequence { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
