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
    public void SaveCard(object sender, EventArgs e)
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

        bool savedSuccessfully = viewModel
            .SaveCard(Quest.Text, Resp.Text, categoryList);

        if (!savedSuccessfully)
        {
            var errorToast = Toast.Make("Erro ao salvar Cards :(");
            errorToast.Show();

            return;
        }

        var successToast = Toast.Make("Salvo com sucesso :)");
        successToast.Show();
    }

}