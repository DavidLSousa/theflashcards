using CommunityToolkit.Maui.Views;

namespace theflashcards.pages;

public partial class EditPopup : Popup
{
	public EditPopup()
	{
		InitializeComponent();
	}

    void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Close();
    }
}