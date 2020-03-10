using System;
using System.IO;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.UWP.LiteDBSample
{
    // This is not the code you're looking for.
    // All the action is in the DataLayer class.
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            if (titleBar != null)
            {
                titleBar.BackgroundColor = Colors.Transparent;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.SlateGray;
                titleBar.ButtonForegroundColor = Color.FromArgb(255, 214, 117, 36);
            }

            this.InitializeComponent();

            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            WriteLog("Ready to go.");
            WriteLog(" ");
        }

        private async void Initialize_Click(object sender, RoutedEventArgs e)
        {
            WriteLog("(Re)create database");
            WriteLog("===================");
            await DataLayer.Reset();
            WriteLog("Done");
            WriteLog(" ");
        }

        private void GettingStarted_Click(object sender, RoutedEventArgs e)
        {
            WriteLog("Basic CRUD queries");
            WriteLog("==================");
            WriteLog(" ");
            WriteLog("All series");
            WriteLog("----------");
            var series = DataLayer.SelectAll();
            foreach (var serie in series)
            {
                WriteLog($"* {serie.Name}");
                if (serie.Seasons != null)
                {
                    foreach (var season in serie.Seasons)
                    {
                        WriteLog($"  * {season.Year}");
                        foreach (var episode in season.Episodes)
                        {
                            WriteLog($"    * {episode.Sequence}. {episode.Title}");
                        }
                    }
                }
            }

            WriteLog(" ");
            WriteLog("Series with a 2018 season");
            WriteLog("-------------------------");
            series = DataLayer.SelectFromYear(2018);
            foreach (var serie in series)
            {
                WriteLog($"* {serie.Name}");
            };

            WriteLog(" ");
            WriteLog("Series with a 2020 season");
            WriteLog("-------------------------");
            series = DataLayer.SelectFromYear(2020);
            foreach (var serie in series)
            {
                WriteLog($"* {serie.Name}");
            };

            WriteLog(" ");
            WriteLog("Create - Update - Delete");
            WriteLog("------------------------");
            var actors = DataLayer.Crud();
            foreach (var actor in actors)
            {
                WriteLog($"* {actor}");
            };

            WriteLog(" ");
            WriteLog("Done");
            WriteLog(" ");
        }

        private void InspectingInternals_Click(object sender, RoutedEventArgs e)
        {
            WriteLog("Inspecting metadata");
            WriteLog("===================");
            WriteLog(" ");
            WriteLog("Database properties");
            WriteLog("-------------------");
            var props = DataLayer.SelectDatabaseProperties();
            foreach (var prop in props)
            {
                WriteLog($"* {prop}");
            }

            WriteLog(" ");
            WriteLog("User collections");
            WriteLog("----------------");
            var cols = DataLayer.SelectUserCollections();
            foreach (var col in cols)
            {
                WriteLog($"* {col}");
            }
            WriteLog(" ");
            WriteLog("Done");
            WriteLog(" ");
        }

        private void AdvancedQueries_Click(object sender, RoutedEventArgs e)
        {
            WriteLog("Expression based queries");
            WriteLog("========================");
            WriteLog(" ");
            WriteLog("All episodes from 2020 seasons");
            WriteLog("------------------------------");
            var seasons = DataLayer.Select2020Seasons();
            foreach (var season in seasons)
            {
                WriteLog($"* {season}");
            }

            WriteLog(" ");
            WriteLog("All season finales");
            WriteLog("------------------");
            seasons = DataLayer.SelectSeasonFinales();
            foreach (var season in seasons)
            {
                WriteLog($"* {season}");
            }

            WriteLog(" ");
            WriteLog("All episodes with 'fight' in their description");
            WriteLog("----------------------------------------------");
            seasons = DataLayer.SelectFightEpisodes();
            foreach (var season in seasons)
            {
                WriteLog($"* {season}");
            }

            WriteLog(" ");
            WriteLog("Done");
            WriteLog(" ");
        }

        private void JoiningDocuments_Click(object sender, RoutedEventArgs e)
        {
            WriteLog("Joining documents");
            WriteLog("=================");
            WriteLog(" ");
            WriteLog("All series with their actor's names");
            WriteLog("-----------------------------------");
            var series = DataLayer.SelectWithActors();
            foreach (var serie in series)
            {
                WriteLog($"* {serie.Name}");
                if (serie.Cast != null && serie.Cast.Length > 0)
                {
                    foreach (var actor in serie.Cast)
                    {
                        WriteLog($"  * {actor.Name}");
                    }
                }
            }

            WriteLog(" ");
            WriteLog("Done");
            WriteLog(" ");
        }

        private void WriteLog(string message = "")
        {
            Log.Text += message + Environment.NewLine;
            LogScroll.ChangeView(null, LogScroll.ExtentHeight, null);
        }

        private async void FileStorage_Click(object sender, RoutedEventArgs e)
        {
            var fileId = "$/series/alteredcarbon.jpg";

            WriteLog("File storage");
            WriteLog("=============");
            WriteLog(" ");
            WriteLog("Importing an image");
            WriteLog("------------------");
            var path = Path.Combine(Windows.Application­Model.Package.Current.Installed­Location.Path, @"./Assets/AlteredCarbon.jpg");
            var fileInfo = DataLayer.SaveFile(fileId, path);
            WriteLog(fileInfo);
            path = Path.Combine(Windows.Application­Model.Package.Current.Installed­Location.Path, @"./Assets/RickAndMorty.jpg");
            fileInfo = DataLayer.SaveFile(@"$/series/rickandmorty.jpg", path);
            WriteLog(fileInfo);

            WriteLog(" ");
            WriteLog("Querying a folder");
            WriteLog("-----------------");
            var files = DataLayer.QueryFolder(@"$/series/");
            foreach (var file in files)
            {
                WriteLog($"  * {file}");
            }

            WriteLog(" ");
            WriteLog("Returning an image");
            WriteLog("------------------");
            var stream = DataLayer.SelectFile(fileId);
            stream.Seek(0, SeekOrigin.Begin);
            var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            await bitmapImage.SetSourceAsync(stream.AsRandomAccessStream());
            SelectedImage.Source = bitmapImage;
            WriteLog("<--- look");

            WriteLog(" ");
            WriteLog("Deleting an image");
            WriteLog("-----------------");
            if (DataLayer.DeleteFile(fileId))
            {
                WriteLog("file deleted");
            }
            else
            {
                WriteLog("file not deleted");
            }

            WriteLog(" ");
            WriteLog("Done");
            WriteLog(" ");
        }
    }
}
