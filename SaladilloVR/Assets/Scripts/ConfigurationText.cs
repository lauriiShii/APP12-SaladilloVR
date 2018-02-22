
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: Configurationtext.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConfigurationText : MonoBehaviour {

    #region Variables
    // Objeto que indica que se ha establecido conexion
    public GameObject connected;
    // Objeto que indica que no se ha establecido conexion
    public GameObject disconnected;
    #endregion

    #region Metodos
    // Use this for initialization
    void Start () {
        // Se recupera el valor de direccion IP almacenado en la configuracion de la aplicacion
        GameManager.ipAddress = PlayerPrefs.GetString(GameManager.IP_ADDRESS);
        // Mostramos la direccion IP
        GetComponent<Text>().text = GameManager.ipAddress;
        // Se comprueba la conectividad con la Web API
        CheckConnectivity();
	}

    /// <summary>
    /// Metodo que comprueba si existe conexion con la Web API.
    /// </summary>
    /// <remarks>
    /// Llamar a la corutina CheckConnectivityWebAPI
    /// para comprobar la conexión.
    /// </remarks>
    private void CheckConnectivity()
    {
        StartCoroutine(CheckConnectivityWebAPI());
    }

    IEnumerator CheckConnectivityWebAPI() {
        /*Cuando metemos codigo dentro de using nos aseguramos de liberarlos de la memoria
         *EscapeUriString asegura que pone bien las direcciones*/

        // Prepara la llamara a la Web API
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(String.Format(GameManager.WEB_API_CHECK_CONECTIVITY, GameManager.ipAddress))))
        {
            // Llamada asincrona para saber si hay error o no
            yield return www.SendWebRequest();

            // Activa el objeto conectect si no da el error 200 sino se activa
            connected.SetActive(www.responseCode == 200);
            disconnected.SetActive(!connected.activeSelf);
        }
    }
    #endregion
}
