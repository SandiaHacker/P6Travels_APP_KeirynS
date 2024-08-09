using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6Travels_APP_KeirynS.Services
{
    public static class WebAPIConnection
    {
        //esta clase auto instancia permite configurar la ruta de consumo base
        //del servicio web API. Normalmente es un nombre DNS como www.misitio.com/api/
        //o la dirección IP del servidor como por ejemplo 85.25.45.10/api o local
        //como 192.168.0.10/api

        public static string BaseURL = "http://192.168.100.15:45459/api/";

        //acá tambien es importante incluir  la inf de seguridad como el API Key
        //ya que debe ser incluido en cada llamada a los end point del API

        public static string ApiKeyName = "ApiKey";
        public static string ApiKeyValue = "sandiaP612342234*";
    }
}
