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
        private readonly Action<Popup> _showPopup;

        // Construtor
        public AllCardsViewModel(Action<Popup> showPopup)
        {
            CardsCollection = new ObservableCollection<Card>();
            Card = new ObservableCollection<Card>();
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

            Card = new ObservableCollection<Card> { card };
        }
        [RelayCommand]
        private async Task Edit(Card card)
        {
            // AllCards
            var filePathAllCards = cardsServices.GetfilePathFor("allCards");
            var cards = await cardsServices.GetDeserializedFile<List<Card>>(filePathAllCards);

            await EditCards(cards, card);
            cardsServices.SaveSerializedFile(filePathAllCards, cards);

            // Specific Directory
            var filePathSpecificDirectory = cardsServices.GetFilePathForCategory(card.Category[^1]);
            var cardsSpecificDirectory = await cardsServices.GetDeserializedFile<List<Card>>(filePathSpecificDirectory);

            await EditCards(cardsSpecificDirectory, card);
            cardsServices.SaveSerializedFile(filePathSpecificDirectory, cardsSpecificDirectory);

            CardsCollection = new ObservableCollection<Card>(cards);

            var popup = new Popup
            {
                BindingContext = this // Set the BindingContext for the popup
            };
            popup.Close();
        }

        [RelayCommand]
        private async Task Delete(Card card)
        {
            // AllCards
            var filePathAllCards = cardsServices.GetfilePathFor("allCards");
            var cards = await cardsServices.GetDeserializedFile<List<Card>>(filePathAllCards);

            await RemoveCards(cards, card.Id);
            cardsServices.SaveSerializedFile(filePathAllCards, cards);

            // Specific Directory
            var filePathSpecificDirectory = cardsServices.GetFilePathForCategory(card.Category[^1]);
            var cardsSpecificDirectory = await cardsServices.GetDeserializedFile<List<Card>>(filePathSpecificDirectory);

            await RemoveCards(cardsSpecificDirectory, card.Id);
            cardsServices.SaveSerializedFile(filePathSpecificDirectory, cardsSpecificDirectory);

            DeleteDirectoriesAndJson(cardsSpecificDirectory, filePathSpecificDirectory, card.Category[^1]);

            // Atualizando view
            CardsCollection = new ObservableCollection<Card>(cards);
        }

        // Métodos
        private async void LoadAllCards()
        {
            try
            {
//#if ANDROID
//                AndroidPermissions androidPermissions = new();
//                bool hasAccess = androidPermissions.CheckDirectoryAccess();

//                if (!hasAccess) return;
//#endif

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
        private void DeleteDirectoriesAndJson(List<Card> cardsSpecificDirectory, string filePathSpecificDirectory, string category)
        {
            if (cardsSpecificDirectory.Count == 0)
                File.Delete(filePathSpecificDirectory);

            var directoryPath = cardsServices.GetFilePathForCategoryWithoutJson(category);
            DeleteEmptyDirectories(directoryPath);
        }
        private void DeleteEmptyDirectories(string directoryPath)
        {
            bool isDirectoryEmpty = !Directory.EnumerateFileSystemEntries(directoryPath).Any();

            if (isDirectoryEmpty)
            {
                Directory.Delete(directoryPath);

                var parentDirectory = Directory.GetParent(directoryPath)?.FullName;

                if (!string.IsNullOrEmpty(parentDirectory))
                {
                    DeleteEmptyDirectories(parentDirectory);
                }
            }
        }
        private async Task RemoveCards(List<Card> cards, Guid id)
        {
            var cardToRemove = cards.FirstOrDefault(c => c.Id == id);

            if (cardToRemove == null) await Toast.Make("Erro ao deletar o card").Show();

            cards.Remove(cardToRemove);
        }
        private async Task EditCards(List<Card> cards, Card updetedCard)
        {
            var cardToEdit = cards.FirstOrDefault(c => c.Id == updetedCard.Id);

            if (cardToEdit == null) await Toast.Make("Erro ao editar o card").Show();

            cardToEdit.Quest = updetedCard.Quest;
            cardToEdit.Resp = updetedCard.Resp;
            cardToEdit.Category = updetedCard.Category;
            // Category, se for mudado precis mudar a localização do card nos diretorios
        }

    }
}
