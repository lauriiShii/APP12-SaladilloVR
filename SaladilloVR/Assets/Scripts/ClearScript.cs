
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: Clear.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScript : MonoBehaviour {

    #region Variables
    // Objeto con la direccion IP instroducida por el usuario
    public Text ipAddress;
    #endregion

    #region Metodos
    /// <summary>
    /// Metodo que se ejecuta cuando se pulsa en el boton Clear
    /// </summary>
    /// <remarks>
    /// Pone la dirección ip a vacio.
    /// </remarks>
    public void Click()
    {
        ipAddress.GetComponent<Text>().text = "";
    }
    #endregion
}
