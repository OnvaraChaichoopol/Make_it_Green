using Make_it_Green.Services;


namespace Make_it_Green;

public partial class TypePage : ContentPage
{
    public int Weight = 0;
    public double rate ;
    public double amount = 0;

    public string Material;

    FirestoreService fs = new FirestoreService();

    public TypePage(string Material)
    {

        InitializeComponent();

        this.Material = Material;
        this.SetMat();

        // ซ่อนแถบ Navigation Bar PlasticPage
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void SetMat()
    {
        if (this.Material == "Plastics")
        {
            ImageBackground.Source = "plastics_bg.png";
            this.rate = 8.0;
        }
        else if (this.Material == "Metals")
        {
            ImageBackground.Source = "metals_bg.png";
            this.rate = 30.0;
        }
        else if (this.Material == "Glass")
        {
            ImageBackground.Source = "glass_bg.png";
            this.rate = 2.0;
        }
        else if (this.Material == "Electronics")
        {
            ImageBackground.Source = "electronics_bg.png";
            this.rate = 5.0;
        }
        else if (this.Material == "Textiles")
        {
            ImageBackground.Source = "textiles_bg.png";
            this.rate = 5.0;
        }
        else if (this.Material == "Paper & Cardboard")
        {
            ImageBackground.Source = "paper_bg.png";
            this.rate = 4.0;
        }
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        GarbageDataModel data = new GarbageDataModel {
            Type = this.Material,
            Weight = this.Weight,
            Price = this.amount,

        };
        await fs.InsertGarbageData(data);
        await Navigation.PushAsync(new GarbageListPage(fs));
    }

    private async void on_canceled(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomePage());
    }


    private void decrease_button_Clicked(object sender, EventArgs e)
    {
        if (Weight > 0)
        {
            Weight--;
            WeightLable.Text = Weight.ToString();
            cal_amount();
        }

    }

    private void increase_button_Clicked(object sender, EventArgs e)
    {
        Weight++;
        WeightLable.Text = Weight.ToString();
        cal_amount();
    }

    private void cal_amount()
    {
        amount = Weight * rate;
        LabelAmount.Text = amount.ToString();

    }
}