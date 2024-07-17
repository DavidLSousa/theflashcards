using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    class NewCardPageViewModel
    {
        readonly CardsServices cardServices = new CardsServices();
        public async void SaveCard(string category, string dataSerialized)
        {
            string rootDir = cardServices.GetRootDirSpecificPlataform();

            string filePath = cardServices.GetFilePathForSave(rootDir, category);

            // Descobrir se o filePath ja existe, se ja existe precisa abrir o arquivo json dentro desse path e edita-lo
            if (!PathExists(filePath))
                await File.WriteAllTextAsync(filePath, dataSerialized);
            else
            {
                // Abrir o arquivo json do path que ja existe passado no category e add a ele o novo card

            }

            System.Diagnostics.Debug.WriteLine($"Directory path: {filePath}");
        }

        bool PathExists(string filePath)
        {
            System.Diagnostics.Debug.WriteLine($"Path exists: {File.Exists(filePath)}");

            return File.Exists(filePath);
        }

    }
}
