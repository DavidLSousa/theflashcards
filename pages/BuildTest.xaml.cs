using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class BuildTest : ContentPage
{
    readonly BuildTestViewModel viewModel = new();

    public BuildTest()
	{
		InitializeComponent();
		BindingContext = new BuildTestViewModel();
	}
}