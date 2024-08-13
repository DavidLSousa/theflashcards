using CommunityToolkit.Maui.Views;
using theflashcards.ViewModels;

namespace theflashcards.pages
{
    public partial class AllCards : ContentPage
    {
        public AllCards()
        {
            InitializeComponent();
            BindingContext = new AllCardsViewModel(DisplayPopup);
        }

        private void DisplayPopup(Popup popup)
        {
            this.ShowPopup(popup);
        }
    } 
}
