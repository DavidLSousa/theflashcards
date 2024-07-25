using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    public partial class BuildTestViewModel : ObservableObject
    {
        readonly CardsServices cardServices = new();
        [ObservableProperty]
        private ObservableCollection<string> _categories;

        [RelayCommand]
        private async void ShowCategory()
        {
            string filePathCategory = cardServices.GetfilePathFor("categories");
            string contentCategories = await cardServices.ReadFile(filePathCategory);

            var categories = JsonSerializer.Deserialize<List<string>>(contentCategories);

            Categories = new ObservableCollection<string>(categories);
        }

        [RelayCommand]
        private void BuildTest()
        {
            // Pegar as categorias marcadas
                // Talvez usando um Dicionario para manter o estado
            // Levar a outra pagina, e nela deve estar o mini teste
        }

        public BuildTestViewModel()
        {
            Categories = [];
            ShowCategory();
        }
    }
}
