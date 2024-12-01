using Make_it_Green.Services;

namespace Make_it_Green;

public partial class HomePage : ContentPage
{
    
	public HomePage()
	{
		InitializeComponent();
		// ซ่อนแถบ Navigation Bar GarbagePage
        NavigationPage.SetHasNavigationBar(this, false);
        
	}

    private async void OnPlasticsClicked(object sender, EventArgs e)
    {
        // Plastics
        await Navigation.PushAsync(new TypePage("Plastics"));
    }
 private async void OnMetalsClicked(object sender, EventArgs e)
    {
        // Metals
        await Navigation.PushAsync(new TypePage("Metals"));
    }
 private async void OnGlassClicked(object sender, EventArgs e)
    {
        // Glass
        await Navigation.PushAsync(new TypePage("Glass"));
    }
    private async void OnElectronicsClicked(object sender, EventArgs e)
    {
        // Electronics
        await Navigation.PushAsync(new TypePage("Electronics"));
    }
    private async void OnTextilesClicked(object sender, EventArgs e)
    {
        // Textiles
        await Navigation.PushAsync(new TypePage("Textiles"));
    }
    private async void OnPaperClicked(object sender, EventArgs e)
    {
        // Paper
        await Navigation.PushAsync(new TypePage("Paper & Cardboard"));
    }
}