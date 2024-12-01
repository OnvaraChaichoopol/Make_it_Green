namespace Make_it_Green;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

		// ซ่อนแถบ Navigation Bar GarbagePage
        NavigationPage.SetHasNavigationBar(this, false);
	}
		

	private async void OnLoginClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new HomePage());
    }

    private async void OnRegisterTapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new RegisterPage());
    }
}