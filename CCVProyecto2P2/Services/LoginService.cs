using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCVProyecto2P2.Models;
using Newtonsoft.Json;

namespace CCVProyecto2P2.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<InfoUsuario> Login(string usuario, string contrasenia)
        {
            var client = new HttpClient();
            var url = "https://dummyjson.com/auth/login";

            var loginData = new
            {
                username = usuario,
                password = contrasenia
            };

            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Autenticación fallida. Por favor, verifica las credenciales.");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            // Deserializar el usuario en un modelo definido
            var user = JsonConvert.DeserializeObject<UsuarioRespuesta>(responseContent);

            var infoUsuario = new InfoUsuario
            {
                Id = user.id,
                NombreUsuario = user.username,
                Contrasenia = contrasenia,
                RolUsuario = AsignarRol(user.username) // Asignar el rol basado en el username
            };

            return infoUsuario;
        }

        private int AsignarRol(string username)
        {
            return username switch
            {
                "emilys" => 1,
                "michaelw" => 2,
                "jamesd" => 2,
                "sophiab" => 3,
                "oliviaw" => 3,
                _ => throw new ArgumentException("Nombre de usuario no válido para asignar un rol")
            };
        }
    }
}