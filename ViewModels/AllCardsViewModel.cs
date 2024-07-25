using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

using theflashcards.Model;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    public partial class AllCardsViewModel : ObservableObject
    {
        // Props
        readonly CardsServices cardsServices = new();
        [ObservableProperty]
        private ObservableCollection<Card> _cardsCollection;

        // Commands
        [RelayCommand]
        private void ToggleAnswerVisibility(Card card)
        {
            if (card == null) return;

            UpdateVisibilityCards(card);
        }

        // Constructor
        public AllCardsViewModel()
        {
            //CardsCollection = new ObservableCollection<Card>();
            CardsCollection = [];

            LoadAllCards();
        }

        // Methods
        private async void LoadAllCards()
        {
            var filePathAllCards = cardsServices.GetfilePathFor("allCards");

            List<Card> cards = await cardsServices.GetDeserializedFile(filePathAllCards);

            foreach (var card in cards)
            {
                CardsCollection.Add(card);
            }
        }
        private async void UpdateVisibilityCards(Card card)
        {
            var filePathAllCards = cardsServices.GetfilePathFor("allCards");

            List<Card> cards = await cardsServices.GetDeserializedFile(filePathAllCards);

            foreach (var currentCard in cards)
                if (currentCard.Id == card.Id) 
                    currentCard.IsAnswerVisible = !currentCard.IsAnswerVisible;

            cardsServices.SaveSerializedFile(filePathAllCards, cards);

            CardsCollection = new ObservableCollection<Card>(cards);
        }

    }
}
