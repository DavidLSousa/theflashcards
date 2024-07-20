using theflashcards.ViewModels;

namespace theflashcards.pages
{
    public partial class AllCards : ContentPage
    {
        public AllCards()
        {
            InitializeComponent();
            BindingContext = new AllCardsViewModel();
        }

    } 
}
