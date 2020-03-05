using System;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.UWP.LiteDBSample
{
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
            WriteLog("-------------------");
            await DataLayer.Reset();
            WriteLog("Done");
            WriteLog(" ");
        }

        private void GettingStarted_Click(object sender, RoutedEventArgs e)
        {
            WriteLog("Basic CRUD queries");
            WriteLog("------------------");
            WriteLog("Selecting all series:");
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

            WriteLog("Selecting series with a 2018 season");
            series = DataLayer.SelectFromYear(2018);
            foreach (var serie in series)
            {
                WriteLog($"* {serie.Name}");
            };

            WriteLog("Selecting series with a 2020 season");
            series = DataLayer.SelectFromYear(2020);
            foreach (var serie in series)
            {
                WriteLog($"* {serie.Name}");
            };

            WriteLog("Done");
            WriteLog(" ");
        }

        private void InspectingInternals_Click(object sender, RoutedEventArgs e)
        {
            WriteLog("Inspecting metadata");
            WriteLog("-------------------");
            WriteLog("Fetching database properties:");
            var props = DataLayer.SelectDatabaseProperties();
            foreach (var prop in props)
            {
                WriteLog($"* {prop}");
            }

            WriteLog("Fetching user collections:");
            var cols = DataLayer.SelectUserCollections();
            foreach (var col in cols)
            {
                WriteLog($"* {col}");
            }

            WriteLog("Done");
            WriteLog(" ");
        }

        private void AdvancedQueries_Click(object sender, RoutedEventArgs e)
        {
            WriteLog("Expression based queries");
            WriteLog("------------------------");
            WriteLog("Fetching all episodes from 2020 seasons:");
            var seasons = DataLayer.Select2020Seasons();
            foreach (var season in seasons)
            {
                WriteLog($"* {season}");
            }

            WriteLog("Fetching all season finales:");
            seasons = DataLayer.SelectSeasonFinales();
            foreach (var season in seasons)
            {
                WriteLog($"* {season}");
            }

            WriteLog("Fetching all episodes with 'fight':");
            seasons = DataLayer.SelectFightEpisodes();
            foreach (var season in seasons)
            {
                WriteLog($"* {season}");
            }

            WriteLog("Done");
            WriteLog(" ");
        }

        private void JoiningDocuments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WriteLog(string message = "")
        {
            Log.Text += message + Environment.NewLine;
            LogScroll.ChangeView(null, LogScroll.ExtentHeight, null);
        }
    }
}
