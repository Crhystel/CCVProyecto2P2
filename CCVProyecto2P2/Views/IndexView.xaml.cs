namespace CCVProyecto2P2.Views;

public partial class IndexView : ContentPage
{
    public IndexView()
    {
        InitializeComponent();
    }
    public void Administrador_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AdministradoresView());
    }
    public void Profesor_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfesoresView());
    }
    public void Estudiante_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EstudiantesView());
    }
}