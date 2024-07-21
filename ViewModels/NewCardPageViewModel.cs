using theflashcards.Services;
using theflashcards.Model;

namespace theflashcards.ViewModels
{
    class NewCardPageViewModel
    {
        readonly CardsServices cardServices = new CardsServices();

        public bool SaveCard(string quest, string resp, string category)
        {
            try
            {
                Card card = new Card
                {
                    Quest = quest,
                    Resp = resp,
                    Category = category
                };

                string filePath = cardServices.GetFilePath(card.Category);

                if (!PathExists(filePath))
                    CreateAndWriteFile(filePath, card);
                else
                    GetAndAddCardInFile(filePath, card);

                return true;

            }catch(Exception e)
            {
                return false;
            }
        }

        private bool PathExists(string filePath) => File.Exists(filePath);
        private void CreateAndWriteFile(string filePath, Card newCardData)
        {
            List<Card> newCards = new List<Card>();
            newCards.Add(newCardData);

            cardServices.SaveSerializedFile(filePath, newCards);
        }
        private async void GetAndAddCardInFile(string filePath, Card newCardData) 
        {
            List<Card> cards = await cardServices.GetDeserializedFile(filePath);
            cards.Add(newCardData);

            cardServices.SaveSerializedFile(filePath, cards);
        }

    }
}
