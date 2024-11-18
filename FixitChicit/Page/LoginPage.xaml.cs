namespace FixitChicit.Page;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void GoToCatrgory(object sender, EventArgs e)
    {
		Navigation.PushAsync(new CategoryPage());
    }
}