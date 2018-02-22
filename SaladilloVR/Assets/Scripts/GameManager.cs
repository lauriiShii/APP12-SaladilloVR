
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: GameManager.cs
///////////////////////////////

public static class GameManager {

    #region Variables
    // Clave para la direccion IP
    public const string IP_ADDRESS = "IP_ADDRESS";
    // Variable para almacenar la direccion IP de la Web API
    public static string ipAddress;
    // Constante con URL del metodo de la webAPI para comprobar la conextividad
    public const string WEB_API_CHECK_CONECTIVITY = "http://{0}/SaladilloVR/api/SaladilloVR/CheckConnectivity";
    // Constante con la URL del metodo de la webAPI para obtener la lista de clientes
    public const string WEB_API_GET_CLIENTS = "http://{0}/SaladilloVR/api/SaladilloVR/GetClients";
    #endregion
}
