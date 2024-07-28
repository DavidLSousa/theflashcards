using CommunityToolkit.Mvvm.ComponentModel;

namespace theflashcards.Model
{
    public partial class Category : ObservableObject
    {
        [ObservableProperty]
        private bool isChecked;

        [ObservableProperty]
        private string name;

    }
}
