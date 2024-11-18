using FixitChicit.Page;
using FixitChicit.Page.DetailPage;

namespace FixitChicit;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();
		MainPage = new NavigationPage(new LoginPage());
	}
}
