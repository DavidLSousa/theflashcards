using System.Text.Json;
using theflashcards.Model;

namespace theflashcards.Services
{
    public class CardsServices
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
                Directory.CreateDirectory(Path.Combine(rootDirApp, "categories"));
            }

            string fullPathCategory = categories[^1];
            string lastCategoryName = fullPathCategory.Split('/').ToList()[^1];

            // Building directories for all categories
            string filePath = @$"{rootDirApp}/{fullPathCategory}";
            string filePathWithCategory = Path
                .Combine(filePath, $"{lastCategoryName}_cards.json");

            return [filePathWithCategory, filePath]; 
        }
        public async Task<T> GetDeserializedFile<T>(string filePath)
        {
            string contentStringJson = await ReadFile(filePath);

            return JsonSerializer.Deserialize<T>(contentStringJson);
        }
        public async void SaveSerializedFile(string filePath, List<Card> newDataCards)
        {
            string jsonString = JsonSerializer.Serialize(newDataCards, options);

            await File.WriteAllTextAsync(filePath, jsonString);
        }

        public async void SaveInAllCardsFile(Card card)
        {
            var filePathAllCards = GetfilePathFor("allCards");

            if (!File.Exists(filePathAllCards))
            {
                var newCards = new List<Card> { card };

                string allCardsSerialized = JsonSerializer.Serialize(newCards, options);
                await File.WriteAllTextAsync(filePathAllCards, allCardsSerialized);
            }
            else
            {
                string contentAllCards = await ReadFile(filePathAllCards);
                var allCardsJson = JsonSerializer.Deserialize<List<Card>>(contentAllCards);

                allCardsJson.Add(card);

                string allCardsSerialized = JsonSerializer.Serialize(allCardsJson, options);
                await File.WriteAllTextAsync(filePathAllCards, allCardsSerialized);
            }



        }
        public async void SaveInCategoryFile(List<string> categories)
        {
            var filePathCategory = GetfilePathFor("categories");

            if (!File.Exists(filePathCategory))
            {
                string categoriesSerialized = JsonSerializer.Serialize(categories, options);
                await File.WriteAllTextAsync(filePathCategory, categoriesSerialized);
            }
            else
            {
                string contentCategories = await ReadFile(filePathCategory);
                var categoriesJson = JsonSerializer.Deserialize<List<string>>(contentCategories);

                // checking if it already exists
                foreach (var currentCategory in categoriesJson)
                    if (categories.Contains(currentCategory)) categories.Remove(currentCategory);
                
                var allCategoriesJson = categoriesJson.Concat(categories);

                string categoriesSerialized = JsonSerializer.Serialize(allCategoriesJson, options);
                await File.WriteAllTextAsync(filePathCategory, categoriesSerialized);
            }
        }

        public string GetfilePathFor(string fileName)
        {
            // Apenas para diretorios: AllCards e Categories
            var rootDirSpecificPlataform = GetRootDirSpecificPlataform();
            return @$"{rootDirSpecificPlataform}/{fileName}/{fileName}.json";
        }
    
        public async Task<List<Card>> GetCardsData(string category)
        {
            var rootPath = GetRootDirSpecificPlataform();
            var fileName = $"{category.Split("/").ToList()[^1]}_cards.json";

            var filePathWithCategory = $"{rootPath}/{category}/{fileName}";

            return await GetDeserializedFile<List<Card>>(filePathWithCategory);
        }
        public List<string> GetValidsCategoriesPaths(List<string> categories)
        {
            var rootPath = GetRootDirSpecificPlataform();

            var CategoriesValids = new List<string>();

            foreach (var category in categories)
            {
                var fileName = $"{category.Split("/").ToList()[^1]}_cards.json";
                
                var filePathWithCategory = $"{rootPath}/{category}/{fileName}";

                if ( File.Exists(filePathWithCategory) )
                {
                    CategoriesValids.Add(category);   
                }
            }

            return CategoriesValids;
        }
    }
}
