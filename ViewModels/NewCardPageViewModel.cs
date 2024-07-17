using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theflashcards.Services;
using theflashcards.Model;
using System.Text.Json;

namespace theflashcards.ViewModels
{
    class NewCardPageViewModel
    {
        readonly CardsServices cardServices = new CardsServices();
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public void SaveCard(string category, Cards newCardData)
        {
            string rootDir = cardServices.GetRootDirSpecificPlataform();

            string filePath = cardServices.GetFilePathForSave(rootDir, category);

            if (!PathExists(filePath))
                CreateAndWriteFile(filePath, newCardData);
            else
                GetAndAddNewCardDataInFile(filePath, newCardData);
        }

        private bool PathExists(string filePath) => File.Exists(filePath);

        private async void CreateAndWriteFile(string filePath, Cards newCardData)
        {
            List<Cards> newCards = new List<Cards>();
            newCards.Add(newCardData);

            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(newCards, options));
        }

        private async void GetAndAddNewCardDataInFile(string filePath, Cards newCardData) 
        {
            List<Cards> cards = await cardServices.GetDeserializedFile(filePath);

            cards.Add(newCardData);

            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(cards, options));
        }

    }
}
