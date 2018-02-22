
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: MovementDisc.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDisc : MonoBehaviour {

    #region Variables
    // Velocidad máxima de desplazamiento
    public float maxSpeed = 0.5f;
    // Fuerza de empuje
    public float pushForce = 10f;
    // Indica si el usuario esta mirando el dico o no
    [HideInInspector]
    public bool isHover = false;
    // Referencia al rigibody que queremos mover
    public Rigidbody rigidbody;
    #endregion

    #region Metodos
	// Update is called once per frame
	void FixedUpdate () {
        if (isHover)
        {
            if (rigidbody.velocity.magnitude < maxSpeed) {
                rigidbody.AddForce((GvrPointerInputModule.Pointer.CurrentRaycastResult.worldPosition - transform.position).normalized * pushForce);
            }
        }
	}

    /// <summary>
    /// Acciones a realizar para el evento mirar al disco
    /// </summary>
    public void StartLookingAtDisc()
    {
        isHover = true;
    }

    /// <summary>
    /// Acciones a realizar para el evento dejar de mirar al disco
    /// </summary>
    public void StopLookingAtDisc()
    {
        isHover = false;
    }
    #endregion
}
