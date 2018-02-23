///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: ClientButtonScript.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientButtonScript : MonoBehaviour {

    #region Metodos
    /// <summary>
    /// Metodo que se ejecuta cuando se pulsa en el boton Save
    /// </summary>
    /// <remarks>
    /// Obtiene la direccion IP introducida por el usuario y la guarda en las preferencias de la aplicacion.
    /// </remarks>
    public void Click()
    {
        // Se guardan los datos del cliente
        LogClick();
    }

    /// <summary>
    /// Metodo que guarda la informacion del cliente
    /// </summary>
    /// <remarks>
    /// Implementa una corutina que conecta con la Web API para 
    /// guardar la información.
    /// </remarks>
    private void LogClick()
    {
        StartCoroutine(LogClientWebAPI());
    }

    IEnumerator LogClientWebAPI() {

        // Construimos la informacion que se envia a la Web API
        WWWForm form = new WWWForm();
        form.AddField("dni", GetComponentInChildren<Text>().text.Split('-')[0].Trim());
        form.AddField("name", GetComponentInChildren<Text>().text.Split('-')[1].Trim());

        // Crea la peticion a la Web API
        using (UnityWebRequest www = UnityWebRequest.Post(
            Uri.EscapeUriString(String.Format(GameManager.WEB_API_LOAD_CLIENT, GameManager.ipAddress)), form))
        {
            // Envia la peticion a la web API y espera la respuesta
            yield return www.SendWebRequest();

            // Acccion a realizar si la peticion si no ha ido bien
            if (!www.isNetworkError)
            {
                GetComponentInParent<AudioSource>().Play();
            }
        }
    }
    #endregion
}
