using CCVProyecto2P2.ViewsAdmin;
using CCVProyecto2P2.ViewsProfesor;

namespace CCVProyecto2P2.Views;

public partial class AdministradoresView : ContentPage
{
	public AdministradoresView()
	{
		InitializeComponent();
	}
    public void CrearProfesor_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PMainPage());
    }
    public void CrearEstudiante_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EMainPage());
    }
    public void CrearCurso_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CrearCursoView());
    }
    public void UnirEstudiante_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UnirEstudianteView());
    }
}