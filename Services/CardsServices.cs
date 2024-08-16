using CommunityToolkit.Maui.Alerts;
using System.Linq;
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
        public async void SaveSerializedFile<T>(string filePath, T data)
        {
            string jsonString = JsonSerializer.Serialize(data, options);

            await File.WriteAllTextAsync(filePath, jsonString);
        }

        // Overloads
        public async Task SaveInAllCardsFile(Card card)
        {
            await SaveInAllCardsFile(new List<Card> { card });
        }
        public async Task SaveInAllCardsFile(List<Card> cards)
        {
            var filePathAllCards = GetfilePathFor("allCards");

            if (!File.Exists(filePathAllCards))
            {
                string allCardsSerialized = JsonSerializer.Serialize(cards, options);
                await File.WriteAllTextAsync(filePathAllCards, allCardsSerialized);
                return;
            }

            string contentAllCards = await ReadFile(filePathAllCards);
            var allCardsJson = JsonSerializer.Deserialize<List<Card>>(contentAllCards);

            allCardsJson.AddRange(cards);

            string uploadedAllCardsSerialized = JsonSerializer.Serialize(allCardsJson, options);
            await File.WriteAllTextAsync(filePathAllCards, uploadedAllCardsSerialized);
        }
        public async Task SaveInCategoryFile(string category)
        {
            await SaveInCategoryFile(new List<string> { category });
        }
        public async Task SaveInCategoryFile(List<string> categories)
        {
            var filePathCategory = GetfilePathFor("categories");

            if (!File.Exists(filePathCategory))
            {
                string categoriesSerialized = JsonSerializer.Serialize(categories, options);
                await File.WriteAllTextAsync(filePathCategory, categoriesSerialized);
                return;
            }

            string contentCategories = await ReadFile(filePathCategory);
            var categoriesJson = JsonSerializer.Deserialize<List<string>>(contentCategories);

            foreach (var category in categories)
            {
                if (!categoriesJson.Contains(category))
                {
                    categoriesJson.Add(category);
                }
            }

            string updatedCategoriesSerialized = JsonSerializer.Serialize(categoriesJson, options);
            await File.WriteAllTextAsync(filePathCategory, updatedCategoriesSerialized);
        }


        public void RemoveCards(List<Card> cards, Guid id)
        {
            var cardToRemove = cards.FirstOrDefault(c => c.Id == id);

            cards.Remove(cardToRemove);
        }
        public async Task RemoveAndSaveCategories(List<Card> cards, String category)
        {
            var filePathCaregories = GetfilePathFor("categories");
            var categoriesData = await GetDeserializedFile<List<string>>(filePathCaregories);

            bool shouldRemove = true;

            // Se ainda houver outro card com essa categoria, impede de remover
            foreach (var card in cards)
            {
                if (card.Category == category) shouldRemove = false;
            }

            if (shouldRemove) categoriesData.Remove(category);

            SaveSerializedFile(filePathCaregories, categoriesData);
        }

        public void EditCards(List<Card> cards, Card updetedCard)
        {

            foreach (var currentCard in cards)
            {
                if (currentCard.Id == updetedCard.Id)
                {
                    currentCard.Quest = updetedCard.Quest;
                    currentCard.Resp = updetedCard.Resp;
                    currentCard.Category = updetedCard.Category;
                }
            }
        }
        public async Task EditAndSaveCategories(List<Card> cards, string UpdatedCategory)
        {
            var filePathCaregories = GetfilePathFor("categories");
            var categoriesData = await GetDeserializedFile<List<string>>(filePathCaregories);

            var cardCategories = cards.Select(card => card.Category).ToHashSet();

            int initialCount = categoriesData.Count;

            categoriesData.RemoveAll(category => !cardCategories.Contains(category));

            if (categoriesData.Count < initialCount)
            {
                categoriesData.Add(UpdatedCategory);
            }

            SaveSerializedFile(filePathCaregories, categoriesData);
        }
    }
}
