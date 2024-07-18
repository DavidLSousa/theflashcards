using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using theflashcards.Model;

namespace theflashcards.ViewModels
{
    public class AllCardsViewModel : INotifyPropertyChanged
    {
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
            // Inicializa a coleção de Cards com um único item
            CardsCollection = new ObservableCollection<Cards>
            {
                new Cards { Quest = "Teste?", Resp = "Teste!?" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
