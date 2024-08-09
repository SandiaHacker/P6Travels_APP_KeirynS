using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace P6Travels_APP_KeirynS.Models
{
    public class User
    {
        //áca no hace falta nombrar el objeto como DTO, solo es necesario en el API
        //De hecho el equipo de desarrollo no deberia saber la forma del 
        //modelo nativo en el API.

        [JsonIgnore]
        public RestRequest Request { get; set; }
        public int UsuarioID { get; set; }

        public string? Correo { get; set; }

        public string? Nombre { get; set; }

        public string? Telefono { get; set; }

        public string? Contrasennia { get; set; }

        public int RolID { get; set; }

        public string? RolDescripcion { get; set; }

        //funcion quee permite agregar un usuario
        public async Task<bool> AddUserAsync()
        {
            try
            {
                //este es el sufijo que completa la ruta de consumo del API
                string RouteSurfix = string.Format("Users/AddUserFromApp");

                string URL = Services.WebAPIConnection.BaseURL + RouteSurfix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la info de seguridad API Key 
                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                //cuando enviamos objetos hacia el API dedbemos seriaolizarlos antes

                string SerializedModel = JsonConvert.SerializeObject(this);
                Request.AddBody(SerializedModel);

                //Ahora se ejecuta la llamada 
                RestResponse response = await client.ExecuteAsync(Request);

                //Validamos el resultado del llamado al API
                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

        }
    }
}
