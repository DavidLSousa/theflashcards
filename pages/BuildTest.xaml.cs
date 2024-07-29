using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class BuildTest : ContentPage
{
    public BuildTest()
	{
		InitializeComponent();
		BindingContext = new BuildTestViewModel(Navigation);
	}
}