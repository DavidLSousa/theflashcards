using System.Text.Json;
using theflashcards.Model;

namespace theflashcards.Services
{
    class CardsServices
    {
        readonly JsonSerializerOptions options = new() { WriteIndented = true };
        private string GetRootDirSpecificPlataform()
        {
            string folderPath;
#if ANDROID
            folderPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
#elif WINDOWS
        folderPath = @"C:\";
#else
        throw new PlatformNotSupportedException("Plataforma não suportada.");
#endif
            string appSpecificPath = Path.Combine(folderPath, "theflashcards");

            return appSpecificPath;
        }
        private async Task<string> ReadFile(string filePath)
        {
            if (!File.Exists(filePath)) return "";

            return await File.ReadAllTextAsync(filePath);
        }
        public List<string> BuildFilePath(List<string> categories)
        {
            string rootDirApp = GetRootDirSpecificPlataform();

            if (!Directory.Exists(rootDirApp))
            {
                Directory.CreateDirectory(rootDirApp);
                Directory.CreateDirectory(Path.Combine(rootDirApp, "allCards"));
            }

            // Building directories for all categories
            string filePath = rootDirApp;
            foreach (var category in categories)
            {
                filePath = Path.Combine(filePath, category);
            }

            string lastCategoryName = categories[^1];
            string filePathWithCategory = Path.Combine(filePath, $"{lastCategoryName}_cards.json");

            return [filePathWithCategory, filePath]; 
        }
        public async Task<List<Card>> GetDeserializedFile(string filePath)
        {
            string contentStringJson = await ReadFile(filePath);

            return JsonSerializer.Deserialize<List<Card>>(contentStringJson);
        }
        public async void SaveSerializedFile(string filePath, List<Card> newDataCards)
        {
            string jsonString = JsonSerializer.Serialize(newDataCards, options);

            await File.WriteAllTextAsync(filePath, jsonString);
        }

        public async void SaveInAllCardsFile(Card card)
        {
            var filePathAllCards = @"C:\theflashcards\allCards\allCards.json";

            if (!File.Exists(filePathAllCards))
            {
                var newCards = new List<Card> { card };

                string allCardsDeserialized = JsonSerializer.Serialize(newCards, options);
                await File.WriteAllTextAsync(filePathAllCards, allCardsDeserialized);
            }
            else
            {
                string contentAllCards = await ReadFile(filePathAllCards);
                var allCardsJson = JsonSerializer.Deserialize<List<Card>>(contentAllCards);

                allCardsJson.Add(card);

                string allCardsDeserialized = JsonSerializer.Serialize(allCardsJson, options);
                await File.WriteAllTextAsync(filePathAllCards, allCardsDeserialized);
            }



        }
    }
}
