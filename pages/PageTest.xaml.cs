using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class PageTest : ContentPage
{
    public PageTest(string selectedCategoriesString)
    {
        InitializeComponent();
        BindingContext = new PageTestViewModel()
        {
            //Categories = selectedCategoriesString.Split(',').ToList()
            Categories = [.. selectedCategoriesString.Split(',')]
        };
    }
}