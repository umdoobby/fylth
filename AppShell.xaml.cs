using Fylth.ViewModels;
using Fylth.Views;

namespace Fylth;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute(nameof(E621ViewPostPage), typeof(E621ViewPostPage));
	}
}
