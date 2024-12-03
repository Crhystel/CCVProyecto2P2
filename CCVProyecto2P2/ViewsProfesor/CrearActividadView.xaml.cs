using Newtonsoft.Json;

namespace CCVProyecto2P2.ViewsProfesor;

public partial class CrearActividadView : ContentPage
{
	public CrearActividadView()
	{
		InitializeComponent();
	}

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var actividad = new Models.Actividad
        {
            Titulo = editorNombre.Text,
            Descripcion = editorDescripción.Text,
            FechaCreacion = FechaInicio.Date,
            FechaEntrega = FechaEntrega.Date
        };

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "actividades.txt");

        try
        {
            // Serializar y guardar la actividad en formato JSON
            var actividades = File.Exists(path)
                ? JsonConvert.DeserializeObject<List<Models.Actividad>>(File.ReadAllText(path)) ?? new List<Models.Actividad>()
                : new List<Models.Actividad>();

            actividades.Add(actividad);
            File.WriteAllText(path, JsonConvert.SerializeObject(actividades));

            await DisplayAlert("Éxito", "Actividad guardada correctamente", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo guardar la actividad: {ex.Message}", "OK");
        }
    }
}
