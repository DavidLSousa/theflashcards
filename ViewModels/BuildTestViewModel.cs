using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using theflashcards.Model;
using theflashcards.pages;
using theflashcards.Services;

namespace theflashcards.ViewModels
{
    // Props
    public partial class BuildTestViewModel : ObservableObject
    {
        readonly CardsServices cardServices = new();
        private readonly INavigation _navigation;

        [ObservableProperty]
        private ObservableCollection<Category> _categories;

        // Constructor
        public BuildTestViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Categories = [];
            _ = ShowCategory();
        }

        // Commands
        [RelayCommand]
        private async Task ShowCategory()
        {
            string filePathCategory = cardServices.GetfilePathFor("categories");

            var allCategoriesPaths = await cardServices.GetDeserializedFile<List<string>>(filePathCategory);
            var validsCategoriesPaths = cardServices.GetValidsCategoriesPaths(allCategoriesPaths);

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

            await _navigation.PushAsync(new PageTest(selectedCategoriesString));
        }

    }
}
