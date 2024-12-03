using CCVProyecto2P2.Views;

namespace CCVProyecto2P2.ViewLogin;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
	}
    public void Ingresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new IndexView());
    }
}