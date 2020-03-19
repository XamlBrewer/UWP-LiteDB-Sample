using LiteDB;

namespace XamlBrewer.UWP.LiteDBSample.Entities
{
    public class Actor
    {
        [BsonId]
        public int ActorId { get; set; }

        public string Name { get; set; }

        public static Actor[] SampleData
        {
            get
            {
                return new Actor[]
                    {
                    new Actor
                    {
                        Name = "Chris Conner"
                    },
                    new Actor
                    {
                        Name = "Renée Elise Goldsberry"
                    },
                    new Actor
                    {
                        Name = "Will Yun Lee"
                    }
                    };
            }
        }
    }
}
