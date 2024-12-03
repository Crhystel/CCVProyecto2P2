using CCVProyecto2P2.Models;
using CCVProyecto2P2.Services.EstudianteService;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace CCVProyecto2P2.ViewsModels
{
    public class EstudianteViewModel : IEstudiante
    {
        public static readonly string baseUrl = "http://192.168.100.20:5000";
        public EstudianteViewModel()
        {
            
        }
        public async Task<bool> AddUpdateEstudianteAsync(Estudiante estudiante)
        {
            string json = JsonConvert.SerializeObject(estudiante);
            StringContent content = new StringContent(json, Encoding.UTF8, "aplicacion/json");
            HttpClient client = new HttpClient();

            if (estudiante.Id == 0)
            {
                string url = baseUrl + "/Estudiantes";
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.PostAsync("", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            else
            {
                string url = baseUrl + "/Estudiantes/{postEstuianteId}"+ estudiante.Id;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.PutAsync("", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteEstudianteAsync(int estudianteId)
        {
            HttpClient client = new HttpClient();
            string url = baseUrl + "/Estudiantes/{deleteEstuianteId}" + estudianteId;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.DeleteAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Estudiante> GetEstudianteAsync(int estudianteId)
        {
            var estudiante = new Estudiante();
            HttpClient client = new HttpClient();
            string url = baseUrl + "/Estudiantes/" + estudianteId;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                estudiante = await responseMessage.Content.ReadFromJsonAsync<Estudiante>();
            }
            return await Task.FromResult(estudiante);
        }

        public async Task<IEnumerable<Estudiante>> GetEstudiantesAsync()
        {
            var estudianteList = new List<Estudiante>();
            HttpClient client = new HttpClient();
            string url = baseUrl + "/Estudiantes" ;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responseMessage = await client.GetAsync("");
            if (responseMessage.IsSuccessStatusCode)
            {
                estudianteList = await responseMessage.Content.ReadFromJsonAsync<List<Estudiante>>();
            }
            return await Task.FromResult(estudianteList);
        }
    }
}
