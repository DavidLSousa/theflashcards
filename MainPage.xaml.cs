﻿using theflashcards.pages;

namespace theflashcards
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToNewCardPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewCard());
        }
        private async void GoToAllCardsPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllCards());
        }
        private async void GoToBuildTestPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuildTest());
        }
        private async void GoToImportCardsPageTest(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImportCards());
        }

        private async void GoToDashboardPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dashboard());
        }
    }

}
