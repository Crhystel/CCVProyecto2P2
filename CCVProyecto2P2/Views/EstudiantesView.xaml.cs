namespace CCVProyecto2P2.Views;
using System.IO;
using Newtonsoft.Json;
public partial class EstudiantesView : ContentPage
{
	public EstudiantesView()
	{
		InitializeComponent();
        CargarActividades();
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