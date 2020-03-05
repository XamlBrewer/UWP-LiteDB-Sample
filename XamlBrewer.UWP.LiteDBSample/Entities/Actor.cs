namespace XamlBrewer.UWP.LiteDBSample.Entities
{
    public class Actor
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public static Actor[] SampleData
        {
            get
            {
                return new Actor[]
                    {
                        new Actor
                        {
                            Name = "Simone Missick"
                        },
                        new Actor
                        {
                            Name = "Lela Loren"
                        },
                        new Actor
                        {
                            Name = "Simone Missick"
                        }
                    };
            }
        }
    }
}
