using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using theflashcards.Model;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    public partial class BuildTestViewModel : ObservableObject
    {
        readonly CardsServices cardServices = new();

        [ObservableProperty]
        private ObservableCollection<Category> _categories;

        public BuildTestViewModel()
        {
            Categories = [];
            _ = ShowCategory();
        }

        [RelayCommand]
        private async Task ShowCategory()
        {
            string filePathCategory = cardServices.GetfilePathFor("categories");

            var categoryNames = await cardServices.GetDeserializedFile<List<string>>(filePathCategory);

            // Checar se existe arquivo json em cada path passado 
            var validsCategoriesPaths = cardServices.GetValidsCategoriesPaths(categoryNames);

            Categories = new ObservableCollection<Category>(validsCategoriesPaths
                .Select(name => new Category 
                { 
                    Name = name, 
                    IsChecked = false 
                }));

        }

        [RelayCommand]
        private async Task BuildTest()
        {
            var selectedCategories = Categories
                .Where(c => c.IsChecked)
                .Select(c => c.Name)
                .ToList();



            var selectedCategoriesString = string.Join(",", selectedCategories);

            await Shell.Current.GoToAsync($"//PageTest?selectedCategories={selectedCategoriesString}");
        }

    }
}
