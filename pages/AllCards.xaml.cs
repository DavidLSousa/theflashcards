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

        public void ShowResp(object sender, EventArgs e)
        {
            //Resplbl.isVisible = true;
            // Para fazer isso será preciso usar ItemTapped ou modificar direto do ViewModel
        }

        public void Next(object sender, EventArgs e)
        {

        }
    } 
}
