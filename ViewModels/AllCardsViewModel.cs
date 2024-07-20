﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using theflashcards.Model;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    public class AllCardsViewModel : INotifyPropertyChanged
    {
        readonly CardsServices cardsServices = new CardsServices();
        private ObservableCollection<Card> _cardsCollection;
        public ICommand ToggleVisibilityAnswerCommand { get; }

        public ObservableCollection<Card> CardsCollection
        {
            get { return _cardsCollection; }
            set
            {
                _cardsCollection = value;
                OnPropertyChanged();
            }
        }

        public AllCardsViewModel()
        {
            CardsCollection = new ObservableCollection<Card>();
            LoadCards();
            ToggleVisibilityAnswerCommand = new Command<Card>(ToggleAnswerVisibility);
        }

        private async void LoadCards()
        {
            // Depois vai precisar receber o filePath de onde vai ser carregado o json
            string filePath = cardsServices.GetFilePath("Teste");
            List<Card> cards = await cardsServices.GetDeserializedFile(filePath);

            foreach (var card in cards)
            {
                CardsCollection.Add(card);
            }
        }
        public void ToggleAnswerVisibility(Card card)
        {
            if (card == null) return;

            //card.IsAnswerVisible = true; // Isso no funciona
            UpdateDataCards(card);
        }

        private async void UpdateDataCards(Card card)
        {
            string filePath = cardsServices.GetFilePath(card.Category);
            List<Card> cards = await cardsServices.GetDeserializedFile(filePath);

            foreach (var currentCard in cards)
                if (currentCard.Id == card.Id) 
                    currentCard.IsAnswerVisible = !currentCard.IsAnswerVisible;

            cardsServices.SaveSerializedFile(filePath, cards);

            CardsCollection = new ObservableCollection<Card>(cards);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
