using CommunityToolkit.Maui.Views;

namespace theflashcards.pages;

public partial class DeletePopup : Popup
{
	public DeletePopup()
	{
		InitializeComponent();
	}

    void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Close();
    }
}