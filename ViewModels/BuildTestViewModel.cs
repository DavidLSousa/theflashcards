using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;
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

            Categories = new ObservableCollection<Category>(categoryNames
                .Select(name => new Category 
                { 
                    Name = name, 
                    IsChecked = false 
                }));

        }

        [RelayCommand]
        private void BuildTest()
        {
            var selectedCategories = Categories
                .Where(c => c.IsChecked)
                .Select(c => c.Name)
                .ToList();

            var message = string.Join(", ", selectedCategories);
            System.Diagnostics.Debug.WriteLine($"Selected categories: {message}");
        }

    }
}
