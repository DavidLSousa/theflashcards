using CommunityToolkit.Maui.Alerts;
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
        private List<string> _categoriesList;

        //private List<Card> currentCardsForTest;
        public List<string> CategoriesList
        {
            get => _categoriesList;
            set 
            {
                _categoriesList = value;
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
                var cardsForTest = new List<Card>();

                var filePathAllCards = cardServices.GetfilePathFor("allCards");
                var cards = await cardServices
                    .GetDeserializedFile<List<Card>>(filePathAllCards);

                foreach (var card in cards)
                {
                    if (CategoriesList.Contains(card.Category))
                    {
                        card.IsAnswerVisible = false;
                        cardsForTest.Add(card); 
                    }
                }

                //currentCardsForTest = cardsForTest;

                CardsForTest = new ObservableCollection<Card>(cardsForTest);
            } 
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($" --- Show Cards Simulado ---");
                System.Diagnostics.Debug.WriteLine(ex.Message);


                await Toast.Make("Erro ao mostrar cards").Show();
            }
        }

        // Methods
        private async void UpdateVisibilityCards(Card card)
        {
            var filePathAllCards = cardServices.GetfilePathFor("allCards");
            var allCards = await cardServices
                .GetDeserializedFile<List<Card>>(filePathAllCards);

            foreach (var currentCard in allCards)
                if (currentCard.Id == card.Id) 
                    currentCard.IsAnswerVisible = !currentCard.IsAnswerVisible;

            cardServices.SaveSerializedFile(filePathAllCards, allCards);

            var cardsForTest = new List<Card>();
            foreach (var currentCard in allCards)
            {
                if (CategoriesList.Contains(currentCard.Category))
                {
                    cardsForTest.Add(currentCard);
                }
            }

            CardsForTest = new ObservableCollection<Card>(cardsForTest);
        }
    }
}
