
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: SphereScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour {

    #region Variables
    // Material por defecto
    public Material sphereMaterial;
    // Material para el hover, es decir cuando pasa el cursor por enccima del gameObject se pondra 
    // de este color
    public Material sphereHoverMaterial;

    #endregion

    #region Metodos
    /// <summary>
    /// Carga el color predeterminado para la esfera.
    /// </summary>
    void Start () {
        GetComponent<Renderer>().material = sphereMaterial;
	}
	
	/// <summary>
    /// Metodo que se ejecuta cuando se empiza a mirar a la sphera.
    /// </summary>
    /// <remarks>
    /// Cambia el color de la esfera al indicado que se debe mostrar
    /// cuando se mira la esfera.
    /// </remarks>
	public void HoveredSphere () {
        GetComponent<Renderer>().material = sphereHoverMaterial;
    }

    /// <summary>
    /// Metodo que se ejecuta cuando se deja de mirar a la sphera.
    /// </summary>
    /// <remarks>
    /// Cambia el color de la esfera al indicado que se debe mostrar
    /// cuando se deja de mirar la esfera.
    /// </remarks>
	public void NotHoveredSphere()
    {
        GetComponent<Renderer>().material = sphereMaterial;
    }
    #endregion
}
