using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

using theflashcards.Model;
using theflashcards.pages;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    public partial class AllCardsViewModel : ObservableObject
    {
        // Props
        readonly CardsServices cardsServices = new();
        [ObservableProperty]
        private ObservableCollection<Card> _cardsCollection;
        [ObservableProperty]
        private ObservableCollection<Card> _card;
        private Card cardToDelete;
        private readonly Action<Popup> _showPopup;

        // Construtor
        public AllCardsViewModel(Action<Popup> showPopup)
        {
            CardsCollection = [];
            Card = [];

            LoadAllCards();

            _showPopup = showPopup;
        }

        // Commands
        [RelayCommand]
        private void ToggleAnswerVisibility(Card card)
        {
            if (card == null) return;

            UpdateVisibilityCards(card);
        }

        [RelayCommand]
        private void ShowEditPopup(Card card)
        {
            var popup = new EditPopup
            {
                BindingContext = this // Set the BindingContext for the popup
            };
            _showPopup?.Invoke(popup);

            Card = [card];
        }
        [RelayCommand]
        private async Task Edit(Card updetedCard)
        {
            var filePathAllCards = cardsServices.GetfilePathFor("allCards");
            var cards = await cardsServices.GetDeserializedFile<List<Card>>(filePathAllCards);

            cardsServices.EditCards(cards, updetedCard);
            await cardsServices.EditAndSaveCategories(cards, updetedCard.Category);

            cardsServices.SaveSerializedFile(filePathAllCards, cards);

            CardsCollection = new ObservableCollection<Card>(cards);

        }

        [RelayCommand]
        private void ShowDeletePopup(Card card)
        {
            var popup = new DeletePopup { BindingContext = this };
            _showPopup?.Invoke(popup);

            cardToDelete = card;
        }
        [RelayCommand]
        private async Task Delete()
        {
            try
            {
                var filePathAllCards = cardsServices.GetfilePathFor("allCards");
                var cards = await cardsServices.GetDeserializedFile<List<Card>>(filePathAllCards);

                cardsServices.RemoveCards(cards, cardToDelete.Id);
                await cardsServices.RemoveAndSaveCategories(cards, cardToDelete.Category);

                cardsServices.SaveSerializedFile(filePathAllCards, cards);

                CardsCollection = new ObservableCollection<Card>(cards);

            } catch (Exception ex)
            {
                await Toast.Make("Erro ao deletar o card").Show();
            }
        }

        // Métodos
        private async void LoadAllCards()
        {
            try
            {
                var filePathAllCards = cardsServices.GetfilePathFor("allCards");

                var cards = await cardsServices.GetDeserializedFile<List<Card>>(filePathAllCards);

                foreach (var card in cards)
                {
                    CardsCollection.Add(card);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"--- LoadAllCards ---");
                System.Diagnostics.Debug.WriteLine(ex);
                await Toast.Make("Erro ao carregar cards").Show();
            }
        }
        
        private async void UpdateVisibilityCards(Card card)
        {
            var filePathAllCards = cardsServices.GetfilePathFor("allCards");

            var cards = await cardsServices.GetDeserializedFile<List<Card>>(filePathAllCards);

            foreach (var currentCard in cards)
                if (currentCard.Id == card.Id)
                    currentCard.IsAnswerVisible = !currentCard.IsAnswerVisible;

            cardsServices.SaveSerializedFile(filePathAllCards, cards);

            CardsCollection = new ObservableCollection<Card>(cards);
        }

    }
}
