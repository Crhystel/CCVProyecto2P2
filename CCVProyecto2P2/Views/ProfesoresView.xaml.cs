using CCVProyecto2P2.ViewsProfesor;

namespace CCVProyecto2P2.Views;

public partial class ProfesoresView : ContentPage
{
	public ProfesoresView()
	{
		InitializeComponent();
	}
    public void CrearActividad_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CrearActividadView());
    }
}