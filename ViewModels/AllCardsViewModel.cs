using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using theflashcards.Model;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    public class AllCardsViewModel : INotifyPropertyChanged
    {
        readonly CardsServices cardsServices = new CardsServices();
        private ObservableCollection<Cards> _cardsCollection;

        public ObservableCollection<Cards> CardsCollection
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
            CardsCollection = new ObservableCollection<Cards>();
            LoadCards();
        }

        private async void LoadCards()
        {
            List<Cards> dataCards = await cardsServices.GetDeserializedFile(cardsServices.GetFilePathForSave("Teste"));
            
            foreach (var card in dataCards)
            {
                CardsCollection.Add(card);
            }
            System.Diagnostics.Debug.WriteLine(dataCards);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
