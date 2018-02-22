
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: ButtonClick.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour {

    #region Variables
    // GameObject que se modifica cuando se pulsa el boton
    public GameObject clickObject;
    #endregion

    #region Metodos
    /// <summary>
    /// Método que ejecuta cualquier botón del juego.
    /// </summary>
    /// <remarks>
    /// Activa y desactiva el objeto sobre el que se apunta o se hace click.
    /// </remarks>
    public void Click()
    {
        // Si el objeto estaa activo, se desactiva y viceversa
        clickObject.SetActive(!clickObject.activeSelf);
    }
    #endregion
}
