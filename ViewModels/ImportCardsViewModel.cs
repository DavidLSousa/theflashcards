using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;
using theflashcards.Model;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    partial class ImportCardsViewModel : ObservableObject
    {
        CardsServices cardServices = new();

        // Constructor
        public ImportCardsViewModel()
        {
        }

        public bool ImportCards(string cardsData)
        {
            var ImportedCards = JsonSerializer.Deserialize<List<Card>>(cardsData);

            cardServices.SaveInAllCardsFile(ImportedCards);

            var cardCategories = ImportedCards.Select(card => card.Category).ToHashSet().ToList();

            cardServices.SaveInCategoryFile(cardCategories);



            return true;
        }
    }
}
