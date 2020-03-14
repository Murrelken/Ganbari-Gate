﻿using System;
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
        public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ItemsDataStore>();
            DependencyService.Register<DecksDataStore>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
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
