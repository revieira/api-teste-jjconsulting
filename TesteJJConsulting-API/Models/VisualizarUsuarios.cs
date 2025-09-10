using System.Text.Json.Serialization;
using TesteJJConsulting_API.Services;

namespace TesteJJConsulting_API.Models
{
    public class Endereco
    {
        public string? city { get; set; }
    }
    
    public class VisualizarUsuarios
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public Endereco? address { get; set; }
        

        public async Task<List<VisualizarUsuarios>> ListAllUsers()
        {
            return await ApiServices.GetAsyncAllUsers();
        }
    }
}
