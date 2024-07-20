using theflashcards.Services;
using theflashcards.Model;
using System.Text.Json;

namespace theflashcards.ViewModels
{
    class NewCardPageViewModel
    {
        readonly CardsServices cardServices = new CardsServices();
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public void SaveCard(string category, Card newCardData)
        {
            string filePath = cardServices.GetFilePath(category);

            if (!PathExists(filePath))
                CreateAndWriteFile(filePath, newCardData);
            else
                GetAndAddNewCardDataInFile(filePath, newCardData);
        }

        private bool PathExists(string filePath) => File.Exists(filePath);

        private async void CreateAndWriteFile(string filePath, Card newCardData)
        {
            List<Card> newCards = new List<Card>();
            newCards.Add(newCardData);

            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(newCards, options));
        }

        private async void GetAndAddNewCardDataInFile(string filePath, Card newCardData) 
        {
            List<Card> cards = await cardServices.GetDeserializedFile(filePath);

            cards.Add(newCardData);

            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(cards, options));
        }

    }
}
