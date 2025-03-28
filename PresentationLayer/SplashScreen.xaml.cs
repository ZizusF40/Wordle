﻿using System.Windows;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize your data asynchronously
            loadingLabel.Content = "Loading words...";
            IWordsFetcherLogic wordsFetcherLogic = new WordsFetcherLogic();
            await wordsFetcherLogic.GetWordsAsync();

            // Create and show the main window
            var wordleUI = new WordleUI(wordsFetcherLogic);
            wordleUI.Show();

            // Close the splash screen
            this.Close();
        }
    }
}
