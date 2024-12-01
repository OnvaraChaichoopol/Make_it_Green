namespace Make_it_Green;

public partial class LastPage : ContentPage
{
	public LastPage()
	{
		InitializeComponent();
		// ซ่อนแถบ Navigation Bar 
        NavigationPage.SetHasNavigationBar(this, false);

	}
	private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomePage());
    }
}