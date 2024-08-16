using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Controls;
using theflashcards.Model;
using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class NewCard : ContentPage
{
    private bool _useSelectedCategories = false;
    readonly NewCardPageViewModel newCardPageViewModel = new();
    public NewCard()
    {
        InitializeComponent();
        BindingContext = newCardPageViewModel;
    }
    public async void SaveCard(object sender, EventArgs e)
    {
        try
        {
            var viewModel = BindingContext as NewCardPageViewModel;

            string category;

            if (_useSelectedCategories)
            {
                category = viewModel.SelectedCategory?.Name;
            }
            else
            {
                category = Category.Text;
            }

            if (Quest.Text == null || Resp.Text == null || string.IsNullOrEmpty(category))
                throw new Exception("Todos os campos devem ser preenchidos.");


            var savedSuccessfully = await newCardPageViewModel
                .SaveCard(Quest.Text, Resp.Text, category);

            if (!savedSuccessfully) throw new Exception("Erro ao salvar Cards :(");

            Quest.Text = null;
            Resp.Text = null;

            await Toast.Make("Salvo com sucesso :)").Show();
        }
        catch (Exception ex)
        {
            await Toast.Make(ex.Message).Show();
        }
    }

    private void ToggleCategorySource(object sender, EventArgs e)
    {
        _useSelectedCategories = !_useSelectedCategories;

        if (_useSelectedCategories)
        {
            ToggleCategorySourceBtn.Text = "Add nova";
            Category.IsEnabled = false;
        }
        else
        {
            ToggleCategorySourceBtn.Text = "Usar existente";
            Category.IsEnabled = true; 
        }
    }
    private void CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var viewModel = BindingContext as NewCardPageViewModel;
        var selectedCategory = (Category)((CheckBox)sender).BindingContext;

        if (e.Value)
        {
            viewModel.SelectedCategory = selectedCategory;

            foreach (var category in viewModel.Categories)
            {
                if (category != selectedCategory && category.IsChecked)
                {
                    category.IsChecked = false;
                }
            }
        }
        else if (viewModel.SelectedCategory == selectedCategory)
        {
            // Deseleciona se a mesma checkbox for desmarcada
            viewModel.SelectedCategory = null; 
        }
    }
}