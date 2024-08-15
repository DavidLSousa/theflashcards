using System.Text.Json;
using theflashcards.Model;

namespace theflashcards.Services
{
    public class CardsServices
    {
        readonly JsonSerializerOptions options = new() { WriteIndented = true };
        private string GetRootAppDirSpecificPlataform()
        {
            string folderPath;
#if ANDROID
            folderPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
#elif WINDOWS
        folderPath = @"C:\";
#else
        throw new PlatformNotSupportedException("Plataforma não suportada.");
#endif

            string rootDirApp = Path.Combine(folderPath, "theflashcards");

            return rootDirApp;
        }
        private async Task<string> ReadFile(string filePath)
        {
            if (!File.Exists(filePath)) return "";

            return await File.ReadAllTextAsync(filePath);
        }
        
        public void BuildFilePath()
        {
            string rootAppDir = GetRootAppDirSpecificPlataform();

            if (!Directory.Exists(rootAppDir))
            {
                Directory.CreateDirectory(rootAppDir);
            }
        }
        
        public string GetfilePathFor(string fileName)
        {
            // Apenas para diretorios: AllCards e Categories
            var rootAppDir = GetRootAppDirSpecificPlataform();
            return @$"{rootAppDir}/{fileName}.json";
        }
        public async Task<T> GetDeserializedFile<T>(string filePath)
        {
            string contentStringJson = await ReadFile(filePath);

            return JsonSerializer.Deserialize<T>(contentStringJson);
        }
        
        public async void SaveInAllCardsFile(Card card)
        {
            var filePathAllCards = GetfilePathFor("allCards");

            if (!File.Exists(filePathAllCards))
            {
                var newCards = new List<Card> { card };

                string allCardsSerialized = JsonSerializer.Serialize(newCards, options);
                await File.WriteAllTextAsync(filePathAllCards, allCardsSerialized);
                return;
            }

            string contentAllCards = await ReadFile(filePathAllCards);
            var allCardsJson = JsonSerializer.Deserialize<List<Card>>(contentAllCards);

            allCardsJson.Add(card);

            string UploadedAllCardsSerialized = JsonSerializer.Serialize(allCardsJson, options);
            await File.WriteAllTextAsync(filePathAllCards, UploadedAllCardsSerialized);

        }
        public async void SaveInCategoryFile(List<string> categories)
        {
            var filePathCategory = GetfilePathFor("categories");

            if (!File.Exists(filePathCategory))
            {
                var lastCategoryAsAList = new List<string>{ categories[^1] };
                string categoriesSerialized = JsonSerializer.Serialize(lastCategoryAsAList, options);
                await File.WriteAllTextAsync(filePathCategory, categoriesSerialized);
                return;
            }

            string contentCategories = await ReadFile(filePathCategory);
            var categoriesJson = JsonSerializer.Deserialize<List<string>>(contentCategories);

            if (categoriesJson.Contains(categories[^1])) return;

            categoriesJson.Add(categories[^1]);

            string UpdatedCategoriesSerialized = JsonSerializer.Serialize(categoriesJson, options);
            await File.WriteAllTextAsync(filePathCategory, UpdatedCategoriesSerialized);
        }
        public async void SaveSerializedFile<T>(string filePath, T data)
        {
            string jsonString = JsonSerializer.Serialize(data, options);

            await File.WriteAllTextAsync(filePath, jsonString);
        }

        public void RemoveCards(List<Card> cards, Guid id)
        {
            var cardToRemove = cards.FirstOrDefault(c => c.Id == id);

            cards.Remove(cardToRemove);
        }
        public async Task RemoveCategories(List<Card> cards, String category)
        {
            var filePathCaregories = GetfilePathFor("categories");
            var categoriesData = await GetDeserializedFile<List<string>>(filePathCaregories);

            bool shouldRemove = true;

            // Se ainda houver outro card com essa categoria, impede de remover
            foreach (var card in cards)
            {
                if (card.Category[^1] == category) shouldRemove = false;
            }

            if (shouldRemove) categoriesData.Remove(category);

            // Salva
            SaveSerializedFile(filePathCaregories, categoriesData);
        }
    }
}
