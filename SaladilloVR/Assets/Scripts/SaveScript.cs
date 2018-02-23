
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: Save.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour {

    #region Variables
    // Objeto con la direccion IP instroducida por el usuario
    public Text ipAddress;
    // Objeto que indica que se ha establecido conexion
    public GameObject connected;
    // Objeto que indica que no se ha establecido conexion
    public GameObject disconnected;
    #endregion

    #region Metodos
    /// <summary>
    /// Metodo que se ejecuta cuando se pulsa en el boton Save
    /// </summary>
    /// <remarks>
    /// Obtiene la direccion IP introducida por el usuario y la guarda en las preferencias de la aplicacion.
    /// </remarks>
    public void Click()
    {
        // Se obtiene la direccion IP introducida por el usuario
        GameManager.ipAddress = ipAddress.GetComponent<Text>().text;
        // Se guarda la direccion IP
        PlayerPrefs.SetString(GameManager.IP_ADDRESS, GameManager.ipAddress);
        // Se almacena el valor en la configuracion de la aplicacion
        PlayerPrefs.Save();
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

    IEnumerator CheckConnectivityWebAPI()
    {
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
