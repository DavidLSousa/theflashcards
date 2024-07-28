using theflashcards.ViewModels;

namespace theflashcards.pages;

[QueryProperty(nameof(SelectedCategories), "selectedCategories")]
public partial class PageTest : ContentPage
{
    private List<string> selectedCategories;
    public string SelectedCategories
    {
        get => string.Join(",", selectedCategories);
        set
        {
            selectedCategories = value?.Split(',').ToList();

            if (BindingContext is PageTestViewModel viewModel)
            {
                viewModel.Categories = selectedCategories;
            }
        }
    }

    public PageTest()
    {
        InitializeComponent();
        BindingContext = new PageTestViewModel();
    }
}