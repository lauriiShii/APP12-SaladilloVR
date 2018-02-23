
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: LoadButtonScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class LoadButtonScript : MonoBehaviour {

    #region Variables
    // Objeto donde se va a crear la informacion de los clientes
    public GameObject information;
    // Objeto que se crea para un cliente
    public GameObject client;
    #endregion

    #region Metodos
    /// <summary>
    /// Metodo que se ejecuta cuando se pulsa el boton Load.
    /// </summary>
    /// <remarks>
    /// Obtiene la lista del cliente.
    /// </remarks>
    public void Click() {
        GetClients();
    }

    /// <summary>
    /// Obtiene la lista de clientes
    /// </summary>
    /// <remarks>
    /// Llama a una corutina que conecta con la Web API
    /// para obtener la información.
    /// </remarks>
    private void GetClients()
    {
        StartCoroutine(GetClientsWebAPI());
    }

    IEnumerator GetClientsWebAPI() {

        // Crea la petición a la Web API
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(String.Format(GameManager.WEB_API_GET_CLIENTS, GameManager.ipAddress))))
        {
            // Hacemos la petición esperando a que nos responda
            yield return www.SendWebRequest();

            // Accion a realizar si la peticion se ha 
            // ejecutado sin error
            if (!www.isNetworkError)
            {
                // Se recupera la lista de clientes
                ClientList clientList = JsonUtility.FromJson<ClientList>(www.downloadHandler.text);
                // Se  recorre la lista de clientes
                for (int i = 0; i < clientList.clients.Length; i++)
                {
                    // Se crea el objeto para un cliente
                    GameObject clientItem = Instantiate(client);
                    // Se asigna el texto que debe mostrar
                    clientItem.GetComponentInChildren<Text>().text =
                        clientList.clients[i].dni + " - " + clientList.clients[i].name;
                    // Se establece su padre que este es la escena
                    clientItem.transform.SetParent(information.transform);
                    // Se posiciona en la escena
                    clientItem.GetComponent<RectTransform>().localPosition = new Vector3(0, (-0.13f) * (i + 1), 0);
                }
            }
        }
    }
    #endregion


    #region Entidades

    [Serializable]
    public class ClientList
    {
        // Se llama clients por que debe coincidir con el nombre de la lista
        // que devuelve el servicio
        public Client[] clients;
    }

    [Serializable]
    public class Client
    {
        public string dni;
        public string name;

        public Client(string dni, string name) {
            this.name = name;
            this.dni = dni;
        }
    }

    #endregion
}
