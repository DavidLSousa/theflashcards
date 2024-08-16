using CommunityToolkit.Maui.Alerts;
using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class ImportCards : ContentPage
{
    ImportCardsViewModel viewModel = new();
    public ImportCards()
	{
		InitializeComponent();
    }

    public async void ImportCardsData(object sender, EventArgs e)
    {
        var savedSuccessfully = viewModel.ImportCards(CardsData.Text);

        if (!savedSuccessfully)
        {
            await Toast.Make("Erro ao importar Cards :(").Show();
            return;
        }

        await Toast.Make("Cards importados :)").Show();
    }
}