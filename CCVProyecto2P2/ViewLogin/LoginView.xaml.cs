using CCVProyecto2P2.Models;
using CCVProyecto2P2.Views;

namespace CCVProyecto2P2.ViewLogin;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
	}
    private async void Ingresar_Clicked(object sender, EventArgs e)
    {
        string usuario = UsuarioEntry.Text; 
        string contrasenia = ContraseniaEntry.Text;

        
        if (usuario == "admin" && contrasenia == "admin")
        {
            await Navigation.PushAsync(new AdministradoresView());
        }
        else
        {
            
            var usuarioAutenticado = await AutenticarUsuarioAsync(usuario, contrasenia);

            if (usuarioAutenticado != null)
            {
                
                switch (usuarioAutenticado.Rol)
                {
                    case RolEnum.Administrador:
                        await Navigation.PushAsync(new AdministradoresView());
                        break;
                    case RolEnum.Profesor:
                        await Navigation.PushAsync(new ProfesoresView());
                        break;
                    case RolEnum.Estudiante:
                        await Navigation.PushAsync(new EstudiantesView());
                        break;
                }
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }
    }


    private async Task<Usuario> AutenticarUsuarioAsync(string nombreUsuario, string contrasenia)
    {
        
        List<Usuario> usuarios = new List<Usuario>
    {
        new Administrador { NombreUsuario = "admin", Contrasenia = "admin", Rol = RolEnum.Administrador },
        new Profesor { NombreUsuario = "profesor1", Contrasenia = "1234", Rol = RolEnum.Profesor },
        new Estudiante { NombreUsuario = "estudiante1", Contrasenia = "1234", Rol = RolEnum.Estudiante }
    };

        return usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasenia == contrasenia);
    }
}