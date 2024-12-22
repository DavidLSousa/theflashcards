namespace theflashcards.ViewModels;

public class DashboardViewModel : ContentView
{
	public DashboardViewModel()
	{
        // Props
        // Constructor
        // Commands
        // Methods
        Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}