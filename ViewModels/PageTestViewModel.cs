using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using theflashcards.Model;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    partial class PageTestViewModel : ObservableObject
    {
        // Props
        CardsServices cardServices = new();
        [ObservableProperty]
        private ObservableCollection<Card> _cardsForTest;
        private List<string> _categories;
        public List<string> Categories
        {
            get => _categories;
            set 
            { 
                _categories = value;
                ShowCards();
            }
        }

        // Constructor
        public PageTestViewModel()
        {
            CardsForTest = [];
        }

        // Commands
        [RelayCommand]
        private void ToggleAnswerVisibility(Card card)
        {
            if (card == null) return;

            UpdateVisibilityCards(card);
        }

        [RelayCommand]
        private async Task ShowCards()
        {
            try
            {
                var allCards = new List<Card>();

                foreach (var category in Categories)
                {
                    var filePathWithCategory = cardServices.GetFilePathForCategory(category);
                    var cards = await cardServices.GetDeserializedFile<List<Card>>(filePathWithCategory);

                    allCards.AddRange(cards);
                }

                CardsForTest = new ObservableCollection<Card>(allCards);
            } 
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($" --- Show Cards Simulado ---");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        // Methods
        private async void UpdateVisibilityCards(Card card)
        {
            var allCards = new List<Card>();

            var filePathOfCurrentCard = cardServices.GetFilePathForCategory(card.Category[^1]);
            var cards = await cardServices.GetDeserializedFile<List<Card>>(filePathOfCurrentCard);

            foreach (var currentCard in cards)
                if (currentCard.Id == card.Id) 
                    currentCard.IsAnswerVisible = !currentCard.IsAnswerVisible;


            foreach (var category in Categories)
            {
                var filePathWithCategory = cardServices.GetFilePathForCategory(category);
                var cardsLoaded = await cardServices.GetDeserializedFile<List<Card>>(filePathWithCategory);

                if (category == card.Category[^1])
                {
                    allCards.AddRange(cards);
                } else
                {
                    allCards.AddRange(cardsLoaded);
                }
            }

            cardServices.SaveSerializedFile(filePathOfCurrentCard, cards);

            CardsForTest = new ObservableCollection<Card>(allCards);
        }
    }
}
