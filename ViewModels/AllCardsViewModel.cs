using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using theflashcards.Model;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    public partial class AllCardsViewModel : ObservableObject
    {
        // Props
        readonly CardsServices cardsServices = new CardsServices();
        [ObservableProperty]
        private ObservableCollection<Card> _cardsCollection;

        // Commands
        [RelayCommand]
        private void ToggleAnswerVisibility(Card card)
        {
            if (card == null) return;

            //card.IsAnswerVisible = true; // Isso no funciona
            UpdateDataCards(card);
        }

        // Constructor
        public AllCardsViewModel()
        {
            CardsCollection = new ObservableCollection<Card>();
            LoadAllCards();
        }

        // Methods
        private async void LoadAllCards()
        {
            // OBS
            string filePath = cardsServices.GetFilePath("Teste");
            List<Card> cards = await cardsServices.GetDeserializedFile(filePath);

            foreach (var card in cards)
            {
                CardsCollection.Add(card);
            }
        }
        private async void UpdateDataCards(Card card)
        {
            // OBS
            string filePath = cardsServices.GetFilePath(card.Category);
            List<Card> cards = await cardsServices.GetDeserializedFile(filePath);

            foreach (var currentCard in cards)
                if (currentCard.Id == card.Id) 
                    currentCard.IsAnswerVisible = !currentCard.IsAnswerVisible;

            cardsServices.SaveSerializedFile(filePath, cards);

            CardsCollection = new ObservableCollection<Card>(cards);
        }

    }
}
