using theflashcards.Services;
using theflashcards.Model;

namespace theflashcards.ViewModels
{
    class NewCardPageViewModel
    {
        readonly CardsServices cardServices = new();

        public bool SaveCard(string quest, string resp, List<string> category)
        {
            try
            {
                var card = new Card
                {
                    Quest = quest,
                    Resp = resp,
                    Category = category
                };

                string filePathWithCategory = cardServices.BuildFilePath(card.Category)[0];

                if (!PathExists(filePathWithCategory))
                    CreateAndWriteFile(card);
                else
                    GetAndAddCardInFile(card);

                cardServices.SaveInAllCardsFile(card);

                return true;

            }catch(Exception e)
            {
                return false;
            }
        }

        private bool PathExists(string filePath) => File.Exists(filePath);
        private void CreateAndWriteFile(Card newCardData)
        {
            string filePathWithoutCategory = cardServices.BuildFilePath(newCardData.Category)[1];
            string filePathWithCategory = cardServices.BuildFilePath(newCardData.Category)[0];

            var newCards = new List<Card>
            {
                newCardData
            };

            Directory.CreateDirectory(filePathWithoutCategory);

            cardServices.SaveSerializedFile(filePathWithCategory, newCards);
        }
        private async void GetAndAddCardInFile(Card newCardData) 
        {
            string filePathWithCategory = cardServices.BuildFilePath(newCardData.Category)[0];

            var cards = await cardServices.GetDeserializedFile(filePathWithCategory);
            cards.Add(newCardData);

            cardServices.SaveSerializedFile(filePathWithCategory, cards);
        }

    }
}
