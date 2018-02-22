
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: WhiterScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriterScript : MonoBehaviour {

    #region Variables
    // Objeto con la direccion IP instroducida por el usuario
    public Text ipAddress;
    #endregion

    #region Metodo
    /// <summary>
    /// Metodo que se ejecuta cuando se pulsa en el boton Write
    /// </summary>
    /// <remarks>
    /// Obtiene el texto del boton y se lo concatena al texto de ipAddress
    /// </remarks>
    public void Click()
    {
        ipAddress.GetComponent<Text>().text += GetComponentInChildren<Text>().text;
    }
    #endregion
}
