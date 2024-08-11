﻿using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using theflashcards.Model;
using theflashcards.Services;

//#if ANDROID
//using Android.App;
//using Android.Content;
//using theflashcards.Platforms.Android;
//#endif

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

        [RelayCommand]
        private async Task Edit(Card card)
        {
            System.Diagnostics.Debug.WriteLine(card);
            // Precisa abrir um popup para add o novo conteudo
            // Esse novo conteudo será add em allcards e em seu diretorio especifico
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

        // Construtor
        public AllCardsViewModel()
        {
            CardsCollection = new ObservableCollection<Card>();
            LoadAllCards();
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
        private async Task RemoveCards(List<Card> cardsSpecificDirectory, Guid id)
        {
            var cardToRemove = cardsSpecificDirectory.FirstOrDefault(c => c.Id == id);

            if (cardToRemove == null) await Toast.Make("Erro ao deletar o card").Show();

            cardsSpecificDirectory.Remove(cardToRemove);
        }


//#if ANDROID
//        // Método para lidar com o resultado da solicitação de acesso ao diretório
//        public void HandleActivityResult(int requestCode, Result resultCode, Intent data)
//        {
//            AndroidPermissions androidPermissions = new();
//            androidPermissions.HandleActivityResult(requestCode, resultCode, data);

//            // Tente carregar os cards novamente após a concessão da permissão
//            LoadAllCards();
//        }
//#endif
    }
}
