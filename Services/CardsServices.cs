using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theflashcards.Services
{
    class CardsServices
    {
        public string GetRootDirSpecificPlataform()
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

        public string GetFilePathForSave(string rootDir, string category)
        {
            if (!Directory.Exists(rootDir))
            {
                Directory.CreateDirectory(rootDir);
            }

            return Path.Combine(rootDir, $"{category}Cards.json");
        }

    }
}
