using FixitChicit.Page;

namespace FixitChicit.Page;

public partial class CategoryPage : ContentPage
{
	public CategoryPage()
	{
		InitializeComponent();
	}

    private void GoToShirt(object sender, EventArgs e)
    {
		Navigation.PushAsync(new DetailPage());
    }

    private void GoToSkirt(object sender, EventArgs e)
    {
		Navigation.PushAsync(new DetailPage());
    }

    private void GoToBag(object sender, EventArgs e)
    {
		Navigation.PushAsync(new DetailPage());
    }

    private void GoToPant(object sender, EventArgs e)
    {
		Navigation.PushAsync(new DetailPage());
    }

    private void GoToShoe(object sender, EventArgs e)
    {
		Navigation.PushAsync(new DetailPage());
    }

    private void GoToAccessory(object sender, EventArgs e)
    {
		Navigation.PushAsync(new DetailPage());
    }

    private void GoToHistory(object sender, EventArgs e)
    {
		Navigation.PushAsync(new HistoryPage());
    }
}