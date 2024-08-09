using P6Travels_APP_KeirynS.ViewModels;
using P6Travels_APP_KeirynS.Models;

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

    private async void BtnAdd_Clicked(object sender, EventArgs e)
    {
		//Debemos hacer una validacion para los campos que son requeridos

		var answer = await DisplayAlert("CONFIRMATION REQUIRED", "Adding a new user. Are you sure?", "Yes", "No");

		if (answer)
		{

			//Extraer el objeto de tipo user role seleccionado en el picker (lista)

			UserRole SelectedUserRole = LstUserRoles.SelectedItem as UserRole;

			bool R = await vm.VmAddUser(TxtEmail.Text.Trim(),TxtName.Text.Trim(),TxtPhone.Text.Trim(),TxtPassword.Text.Trim(),SelectedUserRole.UserRoleId);
			if (R)
			{
				await DisplayAlert(":D", "User added!!", "OK");
				await Navigation.PopAsync();
			}
			else
			{
				await DisplayAlert(":c", "Error", "OK");
			}

        }



    }
}