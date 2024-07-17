namespace theflashcards.pages;

public class AllCards : ContentPage
{
	public AllCards()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = 
                    LayoutOptions.Center, 
                    VerticalOptions = LayoutOptions.Center, 
                    Text = "Welcome to .NET MAUI!"
				}
			}
		};

        //Task.Run(async () =>
        //{
        //    List<Item> items = await LoadItemsFromJsonAsync("items.json");

        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        StackLayout stackLayout = new StackLayout();

        //        foreach (var item in items)
        //        {
        //            var label = new Label
        //            {
        //                Text = $"{item.Name}: {item.Description}",
        //                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
        //            };

        //            stackLayout.Children.Add(label);
        //        }

        //        Content = new ScrollView { Content = stackLayout };
        //    });
        //});
    }
}