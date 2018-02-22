
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: ScrollDown.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour {

    #region Metodos
    /// <summary>
    /// Ejecuta la animación.
    /// </summary>
    void Start () {
        GetComponent<Animator>().Play("ScrollDown");
	}
    #endregion
}
