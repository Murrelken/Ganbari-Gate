using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GanbariGate.Services;
using GanbariGate.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GanbariGate
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "http://localhost:5000";

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DecksDataStore>();
            DependencyService.Register<CardsDataStore>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            try
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "testDB.db3");
                var bytes = File.ReadAllBytes(path);
                var fileCopyName = $"/sdcard/Database_{DateTime.Now:dd-MM-yyyy_HH-mm-ss-tt}.db3";
                File.WriteAllBytes(fileCopyName, bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.Message);
            }

            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
