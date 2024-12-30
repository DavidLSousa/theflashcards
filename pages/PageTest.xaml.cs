using CommunityToolkit.Maui.Views;
using theflashcards.Model;
using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class PageTest : ContentPage
{
    public PageTest(string selectedCategoriesString)
    {
        InitializeComponent();

        BindingContext = new PageTestViewModel(
            popup => this.ShowPopup(popup), 
            Navigation
        )
        {
            CategoriesList = selectedCategoriesString.Split(',').ToList()
        };
    }

    void OnAnswerCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var viewModel = BindingContext as PageTestViewModel;
        var selectedRadioButton = (RadioButton)sender;
        var card = (Card)selectedRadioButton.BindingContext as Card;

        if (viewModel != null && e.Value) // Executar apenas se marcado
        {
            var answer = bool.Parse(selectedRadioButton.Value.ToString()); 
            viewModel.SelectAnswerCommand.Execute((card, answer));
        }
    }

    void OnDifficultyCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var viewModel = BindingContext as PageTestViewModel;
        var selectedRadioButton = (RadioButton)sender;
        var card = (Card)selectedRadioButton.BindingContext as Card;

        if (viewModel != null && e.Value) // Executar apenas se marcado
        {
            var difficulty = (String)selectedRadioButton.Value; 
            viewModel.SelectDifficultyCommand.Execute((card, difficulty));
        }
    }

}
