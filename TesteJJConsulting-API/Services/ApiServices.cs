using Newtonsoft.Json;
using TesteJJConsulting_API.Models;

namespace TesteJJConsulting_API.Services
{
    public class ApiServices
    {

        public static async Task<List<VisualizarUsuarios>> GetAsyncAllUsers()
        {
            HttpClient client = new HttpClient();
            string url = "https://jsonplaceholder.typicode.com/users";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var objResponse = JsonConvert.DeserializeObject<List<VisualizarUsuarios>>(jsonResponse);
                return objResponse;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                return new List<VisualizarUsuarios>();
            }
        }

        public static async Task<List<ExibirDetalheUsuario>> GetAsyncUserById(int id)
        {
            HttpClient client = new HttpClient();
            string url = $"https://jsonplaceholder.typicode.com/users/{id}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var objResponse = JsonConvert.DeserializeObject<ExibirDetalheUsuario>(jsonResponse);
                // Retorna uma lista contendo o usuário (ou vazia se null)
                return objResponse != null ? new List<ExibirDetalheUsuario> { objResponse } : new List<ExibirDetalheUsuario>();
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                return new List<ExibirDetalheUsuario>();
            }
        }
    }
}


