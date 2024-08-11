using CommunityToolkit.Maui.Alerts;
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
        // Propriedades
        readonly CardsServices cardsServices = new();
        [ObservableProperty]
        private ObservableCollection<Card> _cardsCollection;

        // Comandos
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
            // Obtendo de onde remover
            var filePathAllCards = cardsServices.GetfilePathFor("allCards");
            var filePathSpecificDirectory = cardsServices.GetFilePathForCategory(card.Category[^1]);

            var cards = await cardsServices.GetDeserializedFile<List<Card>>(filePathAllCards);
            var cardsSpecificDirectory = await cardsServices.GetDeserializedFile<List<Card>>(filePathSpecificDirectory);

            // Achando card pra remover
            var cardToRemove = cards.FirstOrDefault(c => c.Id == card.Id);
            var cardSpecificDirectoryToRemove = cardsSpecificDirectory.FirstOrDefault(c => c.Id == card.Id);

            if (cardToRemove == null) await Toast.Make("Erro ao deletar o card").Show();
            if (cardSpecificDirectoryToRemove == null) await Toast.Make("Erro ao deletar o card").Show();

            // Removendo e Salvando
            cards.Remove(cardToRemove);
            cardsServices.SaveSerializedFile(filePathAllCards, cards);

            cardsSpecificDirectory.Remove(cardSpecificDirectoryToRemove);
            cardsServices.SaveSerializedFile(filePathSpecificDirectory, cardsSpecificDirectory);

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
