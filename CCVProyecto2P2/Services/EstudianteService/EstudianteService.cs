using CCVProyecto2P2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CCVProyecto2P2.Services.EstudianteService
{
    public class EstudianteService : IEstudiante
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "http://192.168.100.20:5057";

        public EstudianteService()
        {
            _client = new HttpClient();
        }

        public async Task<bool> AddUpdateEstudianteAsync(Estudiante estudiante)
        {
            var json = JsonSerializer.Serialize(estudiante);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response;

            if (estudiante.Id == 0) 
            {
                response = await _client.PostAsync($"{_baseUrl}/Estudiantes", content);
            }
            else 
            {
                response = await _client.PutAsync($"{_baseUrl}/Estudiantes/{estudiante.Id}", content);
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEstudianteAsync(int estudianteId)
        {
            var response = await _client.DeleteAsync($"{_baseUrl}/Estudiantes/{estudianteId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Estudiante> GetEstudianteAsync(int estudianteId)
        {
            var response = await _client.GetAsync($"{_baseUrl}/Estudiantes/{estudianteId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Estudiante>();
            }
            return null;
        }

        public async Task<IEnumerable<Estudiante>> GetEstudiantesAsync()
        {
            var response = await _client.GetAsync($"{_baseUrl}/Estudiantes");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Estudiante>>();
            }
            return new List<Estudiante>();
        }
    }
}
