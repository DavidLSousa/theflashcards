using System.Text.Json;
using theflashcards.Model;

namespace theflashcards.Services
{
    class CardsServices
    {
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
        public string GetFilePathForSave(string category)
        {
            string rootDir = GetRootDirSpecificPlataform();

            if (!Directory.Exists(rootDir))
            {
                Directory.CreateDirectory(rootDir);
            }

            return Path.Combine(rootDir, $"{category}Cards.json");
        }

        public async Task<List<Cards>> GetDeserializedFile(string filePath)
        {
            string contentStringJson = await ReadFile(filePath);

            return JsonSerializer.Deserialize<List<Cards>>(contentStringJson);
        }
    }
}
