namespace Make_it_Green;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();

		// ซ่อนแถบ Navigation Bar GarbagePage
        NavigationPage.SetHasNavigationBar(this, false);
	}
	
	private async void OnRegisterClicked(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
		    string.IsNullOrWhiteSpace(EmailEntry.Text) ||
			string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
			string.IsNullOrWhiteSpace(PhoneEntry.Text))
		{
			await DisplayAlert("An error occurred","Please complete all the fields","OK");
			return;
		}
		//สมัครสมาชิกสำเร็จ
		await DisplayAlert("Sign Up Successful!","Welcome to Make It Green","OK");
		await Navigation.PushAsync(new HomePage());
	}
}