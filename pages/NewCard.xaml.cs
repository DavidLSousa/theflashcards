using CommunityToolkit.Maui.Alerts;
using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class NewCard : ContentPage
{
    readonly NewCardPageViewModel viewModel = new();
    public NewCard()
    {
        InitializeComponent();
    }
    public async void SaveCard(object sender, EventArgs e)
    {
        // Isso precisa passar pra view movel e usar o Binding
        var categoryList = new List<string>();
        var currentPathCategory = string.Empty;

        foreach (var currentCategory in Category.Text.Split('/').ToList())
        {
            currentPathCategory = string.IsNullOrEmpty(currentPathCategory) 
                ? currentCategory 
                : $"{currentPathCategory}/{currentCategory}";

            categoryList.Add(currentPathCategory);
        }

        var savedSuccessfully = await viewModel
            .SaveCard(Quest.Text, Resp.Text, categoryList);

        if (!savedSuccessfully)
        {
            await Toast.Make("Erro ao salvar Cards :(").Show();

            return;
        }

        await Toast.Make("Salvo com sucesso :)").Show();
    }

}