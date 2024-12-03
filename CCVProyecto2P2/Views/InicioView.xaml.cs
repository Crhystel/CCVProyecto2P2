using CCVProyecto2P2.ViewLogin;

namespace CCVProyecto2P2.Views;

public partial class InicioView : ContentPage
{
	public InicioView()
	{
		InitializeComponent();
	}
    public void Ingresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginView());
    }
}