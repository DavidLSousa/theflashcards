using theflashcards.Services;
using theflashcards.Model;
using CommunityToolkit.Maui.Alerts;

namespace theflashcards.ViewModels
{
    class NewCardPageViewModel
    {
        readonly CardsServices cardServices = new();

        public async Task<bool> SaveCard(string quest, string resp, List<string> category)
        {
            try
            {
                var card = new Card
                {
                    Quest = quest,
                    Resp = resp,
                    Category = category
                };

                cardServices.BuildFilePath();

                cardServices.SaveInAllCardsFile(card);
                cardServices.SaveInCategoryFile(card.Category);

                return true;

            }catch(Exception ex)
            {

                System.Diagnostics.Debug.WriteLine($"--- SaveCards ---");
                System.Diagnostics.Debug.WriteLine(ex);

                await Toast.Make("Erro ao salvar cards :(").Show();
                return false;
            }
        }

    }
}
