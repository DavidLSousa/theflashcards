using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using theflashcards.Model;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    partial class PageTestViewModel : ObservableObject
    {
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

        public PageTestViewModel()
        {
            CardsForTest = [];
        }

        [RelayCommand]
        private async Task ShowCards()
        {
            var allCards = new List<Card>();

            foreach (var category in Categories)
            {
                var cards = await cardServices.GetCardsData(category);

                allCards.AddRange(cards);
            }

            System.Diagnostics.Debug.WriteLine(allCards);
            System.Diagnostics.Debug.WriteLine(CardsForTest);


            CardsForTest = new ObservableCollection<Card>(allCards);
        }

        private async Task GetCardsOfCategories()
        {
            
        }
    }
}
