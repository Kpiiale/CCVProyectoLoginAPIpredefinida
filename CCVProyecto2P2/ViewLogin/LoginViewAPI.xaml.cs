using CCVProyecto2P2.Models;
using CCVProyecto2P2.Services;
using CCVProyecto2P2.Views;

namespace CCVProyecto2P2.ViewLogin;

public partial class LoginViewAPI : ContentPage
{
    readonly ILoginRepository _loginRepository = new LoginService();
    public LoginViewAPI()
    {
        InitializeComponent();
    }

    private async void IngresarAPi_Clicked(object sender, EventArgs e)
    {
        string usuario = UsuarioEntry.Text;
        string contrasenia = ContraseniaEntry.Text;

        if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia))
        {
            await DisplayAlert("Advertencia", "Por favor ingresar usuario y contraseña", "Ok");
            return;
        }

       
        InfoUsuario userInfo = await _loginRepository.Login(usuario, contrasenia);

        if (userInfo != null)
        {
            
            switch (userInfo.RolUsuario)
            {
                case 1:
                    await Navigation.PushAsync(new AdministradoresView());
                    break;
                case 2:
                    await Navigation.PushAsync(new ProfesoresView());
                    break;
                case 3:
                    await Navigation.PushAsync(new EstudiantesView());
                    break;
                default:
                    await DisplayAlert("Advertencia", "Rol no reconocido", "Ok");
                    break;
            }
        }
        else
        {
            await DisplayAlert("Advertencia", "El usuario o contraseña son incorrectos", "Ok");
        }
    }
}