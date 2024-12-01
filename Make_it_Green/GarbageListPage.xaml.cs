using Make_it_Green.Services;


namespace Make_it_Green;

public partial class GarbageListPage : ContentPage
{


    List<GarbageDataModel> garbages;
    FirestoreService firestoreService;
    public GarbageListPage(FirestoreService firestoreService)
    {
        InitializeComponent();
        this.firestoreService = firestoreService;
        this.LoadData();
        // ซ่อนแถบ Navigation Bar 
        NavigationPage.SetHasNavigationBar(this, false);

    }

    private async void LoadData()
    {
        this.garbages = await firestoreService.GetAllGarbageData();
        GabagesCollectionView.ItemsSource = this.garbages;
    }


    private async void OnLabelTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomePage());
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LastPage());
    }

}