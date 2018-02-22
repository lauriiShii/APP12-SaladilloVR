
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: Delete.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteScript : MonoBehaviour {

    #region Variables
    // Objeto con la direccion IP instroducida por el usuario
    public Text ipAddress;
    #endregion

    #region Metodos
    /// <summary>
    /// Metodo que se ejecuta cuando se pulsa en el boton Delete
    /// </summary>
    /// <remarks>
    /// Obtiene la direccion IP introducida por el usuario, se le suprime el 
    /// último caracter y se le asigna a la ip.
    /// </remarks>
    public void Click()
    {
        string text = ipAddress.GetComponent<Text>().text;

        if (text.Length > 0)
        {
            text = text.Substring(0, text.Length - 1);
        }
        ipAddress.GetComponent<Text>().text = text;
    }
    #endregion
}
