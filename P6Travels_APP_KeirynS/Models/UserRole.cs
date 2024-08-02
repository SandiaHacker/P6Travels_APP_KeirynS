using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P6Travels_APP_KeirynS.Models
{
    public class UserRole
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }

        //Atributos de la clase, en este ejemplo usaremos la clase nativa
        //luego lo cambiamos por el DTO
        public int UserRoleId { get; set; }

        public string UserRoleDescription { get; set; } = null!;

        //crear la funión que consume el get que entrega todos los roles 
        //desde el API

        public async Task<List<UserRole>> GetUserRolesAsync()
        {
            try
            {
                //este es el sufijo que completa la ruta de consumo del API
                string RouteSurfix = string.Format("UserRole");

                string URL = Services.WebAPIConnection.BaseURL + RouteSurfix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la info de seguridad API Key 
                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                //Agregar la info de codificacion (opcional)
                Request.AddHeader(Services.WebAPIConnection.ContentType, Services.WebAPIConnection.MimeType);

                //Ahora se ejecuta la llamada 
                RestResponse response = await client.ExecuteAsync(Request);

                //Validamos el resultado del llamado al API
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    //usamos newtonsoft para descomponer el JSON de respuesta del API y convertirlo
                    //en un objeto de tipo UserRole que se pueda entender en la progra

                    var list = JsonConvert.DeserializeObject<List<UserRole>>(response.Content);
                    return list;
                }
                else
                {
                    return null;
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
