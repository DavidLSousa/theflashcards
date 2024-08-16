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
        var savedSuccessfully = await viewModel
            .SaveCard(Quest.Text, Resp.Text, Category.Text);

        if (!savedSuccessfully)
        {
            await Toast.Make("Erro ao salvar Cards :(").Show();

            return;
        }

        await Toast.Make("Salvo com sucesso :)").Show();
    }

}