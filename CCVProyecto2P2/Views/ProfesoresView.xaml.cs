using CCVProyecto2P2.ViewsProfesor;
using Newtonsoft.Json;
using System.IO;


namespace CCVProyecto2P2.Views;

public partial class ProfesoresView : ContentPage
{
	public ProfesoresView()
	{
		InitializeComponent();
        CargarActividades();
	}
    public void CrearActividad_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CrearActividadView());
    }
    private void CargarActividades()
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "actividades.txt");

        if (File.Exists(path))
        {
            var actividades = JsonConvert.DeserializeObject<List<Models.Actividad>>(File.ReadAllText(path)) ?? new List<Models.Actividad>();
            ActividadesCollection.ItemsSource = actividades;
        }
    }
}