using theflashcards.Services;
using theflashcards.Model;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace theflashcards.ViewModels
{
    partial class NewCardPageViewModel : ObservableObject
    {
        // Props
        readonly CardsServices cardServices = new();
        private bool AreCategoriesVisible = false;
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        [ObservableProperty]
        private ObservableCollection<Category> _categories;

        // Constructor
        public NewCardPageViewModel()
        {
            Categories = new ObservableCollection<Category>();
        }

        //Commands
        [RelayCommand]
        private async Task ToogleVisibilitCategories()
        {
            try 
            { 
                AreCategoriesVisible = !AreCategoriesVisible;

                if (AreCategoriesVisible)
                {
                    string filePathCategories = cardServices.GetfilePathFor("categories");

                    var allCategoriesPaths = await cardServices
                        .GetDeserializedFile<List<string>>(filePathCategories);

                    Categories = new ObservableCollection<Category>(allCategoriesPaths
                        .Select(name => new Category
                        {
                            Name = name,
                            IsChecked = false
                        }));
                }
                else
                {
                    Categories = new ObservableCollection<Category>();
                }
            } 
            catch (Exception ex)
            {
                await Toast.Make("Erro ao buscar categorias").Show();
            }
        }

        // Methods
        public async Task<bool> SaveCard(string quest, string resp, string category)
        {
            try
            {
                var card = new Card
                {
                    Quest = quest,
                    Resp = resp,
                    Category = category
                };

                cardServices.BuildFilePath();

                cardServices.SaveInAllCardsFile(card);
                cardServices.SaveInCategoryFile(card.Category);

                return true;

            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine($"--- SaveCards ---");
                System.Diagnostics.Debug.WriteLine(ex);

                await Toast.Make("Erro ao salvar cards :(").Show();
                return false;
            }
        }

    }
}
