using LiteDB;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XamlBrewer.UWP.LiteDBSample.Entities;

namespace XamlBrewer.UWP.LiteDBSample
{
    public static class DataLayer
    {
        public static Task Reset()
        {
            return Task.Run((System.Action)(() =>
            {
                using (var db = MyDatabase)
                {
                    // Remove collection.
                    db.DropCollection("series");
                    // col.DeleteMany(s => true);

                    // Get a collection (create it if it doesn't exist)
                    var seriesCollection = db.GetCollection<Series>("series");

                    // Index on Name.
                    seriesCollection.EnsureIndex(x => x.Name);

                    // Populate.
                    foreach (var series in Series.SampleData)
                    {
                        seriesCollection.Insert(series);
                    }

                    // Get Altered Carbon
                    var ac = seriesCollection.FindOne(s => s.Name == "Altered Carbon");

                    db.DropCollection("actors");
                    var actorsCollection = db.GetCollection<Actor>("actors");
                    foreach (var actor in Actor.SampleData)
                    {
                        actorsCollection.Upsert(actor);
                        if (ac.Cast == null)
                        {
                            ac.Cast = new Actor[0];
                        }
                        ac.Cast = ac.Cast.Append(actor).ToArray();
                        seriesCollection.Update(ac);
                    }

                    // Get Formula1: Drive to survive
                    var f1 = seriesCollection.FindOne(s => s.Name == "Formula1: Drive to survive");

                    var drivers = new List<Actor>
                    {
                        new Actor { Name = "Alex Albon" },
                        new Actor { Name = "Carlos Sainz" },
                        new Actor { Name = "Charles Leclerc" }
                    };
                    actorsCollection.Upsert(drivers); // It doesn't work without this - without a warning.
                    f1.Cast = drivers.ToArray();
                    seriesCollection.Upsert(f1);

                    // Get Rick & Morty
                    var rm = seriesCollection.FindOne(s => s.Name == "Rick and Morty");

                    var cartoons = new List<Actor>
                    {
                        new Actor { Name = "Rick Sanchez" },
                        new Actor { Name = "Morty Smith" },
                        new Actor { Name = "Mr. Meeseeks" }
                    }; 
                    rm.Cast = cartoons.ToArray();
                    db.BeginTrans();
                    actorsCollection.Upsert(cartoons); // Actors added.
                    seriesCollection.Upsert(rm);
                    // actorsCollection.Upsert(cartoons); // Actors not added - even inside a transaction the order is important.
                    db.Commit();
                }
            }));
        }

        public static List<Series> SelectAll()
        {
            using (var db = MyDatabase)
            {
                var col = db.GetCollection<Series>("series");
                return col.FindAll().ToList();
            }
        }

        public static List<Series> SelectFromYear(int year)
        {
            using (var db = MyDatabase)
            {
                var col = db.GetCollection<Series>("series");
                return col
                    .Query()
                    .Where(x => x.Seasons.Select(s => s.Year).Any(y => y == year))
                    .OrderBy(x => x.Name)
                    .ToList();
            }
        }

        public static IEnumerable<string> SelectDatabaseProperties()
        {
            using (var db = MyDatabase)
            {
                var col = db.GetCollection("$database");
                var doc = col.FindAll().ToList().First();
                foreach (var item in doc.Keys)
                {
                    yield return $"{item}: {doc[item]}";
                }
            }
        }

        public static IEnumerable<string> SelectUserCollections()
        {
            using (var db = MyDatabase)
            {
                var col = db.GetCollection("$cols");
                //var cols = col.Find(BsonExpression.Create("$.type = 'user'")).ToList();
                var cols = col.Find("$.type = 'user'").ToList();
                var name = "name";
                foreach (var item in cols)
                {
                    yield return $"{item[name]}";
                }
            }
        }

        public static IEnumerable<string> Select2020Seasons()
        {
            using (var db = MyDatabase)
            {
                // This year's episodes.
                var reader = db.Execute("SELECT $.Name, $.Seasons[@.Year = 2020].Episodes[*].Title AS Episodes FROM series");

                while (reader.Read())
                {
                    yield return reader.Current.ToString();
                }
            }
        }

        public static IEnumerable<string> SelectSeasonFinales()
        {
            using (var db = MyDatabase)
            {
                // Season finales per season.
                var reader = db.Execute("SELECT $.Name, $.Seasons[*].Episodes[-1] AS SeasonFinales FROM series");

                while (reader.Read())
                {
                    yield return reader.Current.ToString();
                }
            }
        }

        public static IEnumerable<string> SelectFightEpisodes()
        {
            using (var db = MyDatabase)
            {
                // Episodes about fighting.
                var reader = db.Execute("SELECT $.Name, $.Seasons[*].Episodes[@.Description LIKE '%fight%'] AS Fights FROM series");

                while (reader.Read())
                {
                    yield return reader.Current.ToString();
                }
            }
        }

        public static List<Series> SelectWithActors()
        {
            using (var db = MyDatabase)
            {
                var col = db.GetCollection<Series>("series");
                return col
                    .Query()
                    .Include(s => s.Cast)
                    .OrderBy(x => x.Name)
                    .ToList();
            }
        }

        private static LiteDatabase MyDatabase
        {
            get
            {
                var databaseName = "MySeries";
                var filePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, databaseName);

                return new LiteDatabase(filePath);
            }
        }
    }
}
