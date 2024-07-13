using theflashcards.pages;

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
        private void SearchCards(object sender, EventArgs e) { }
        private void BuildTest(object sender, EventArgs e) { }
        private void Logout(object sender, EventArgs e) { }
    }

}
