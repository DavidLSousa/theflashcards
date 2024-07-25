using theflashcards.ViewModels;

namespace theflashcards.pages;

public partial class BuildTest : ContentPage
{
    readonly BuildTestViewModel viewModel = new();

    public BuildTest()
	{
		InitializeComponent();
	}

	public void BuildMiniTest(object sender, EventArgs e)
	{
		viewModel.BuildTest();
	}
}