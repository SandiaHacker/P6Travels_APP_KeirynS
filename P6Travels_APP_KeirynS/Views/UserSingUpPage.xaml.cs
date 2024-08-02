using P6Travels_APP_KeirynS.ViewModels;

namespace P6Travels_APP_KeirynS.Views;

public partial class UserSingUpPage : ContentPage
{
	//definicion del objetivo viewmodel que gestiona la pagina

	UserViewModel? vm;

	public UserSingUpPage()
	{
		InitializeComponent();

		BindingContext = vm = new UserViewModel();

		LoadUserRolesList();
	}

	private async void LoadUserRolesList()
	{
		LstUserRoles.ItemsSource = await vm.VmGetUserRolesAsync();
	}

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}