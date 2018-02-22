
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: MoveJoestick.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoestick : MonoBehaviour {

    #region Variables
    // Velocidad máxima de desplazamiento
    public float maxSpeed = 0.5f;
    // Fuerza de empuje
    public float pushForce = 10f;
    // Referencia al rigibody que queremos mover
    public Rigidbody rigidbody;
    #endregion

    #region Metodos
    // Use this for initialization
    void Awake () {
        rigidbody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        // Recuperamos el valor de los ejes horizontales y verticales
        // Son  valores normalizados que van de 0 a 1
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Calculamos el vector de movimiento con la direccion a la que mira la camara
        Vector3 moveDirection = (h * Camera.main.transform.right + v * Camera.main.transform.forward).normalized;

        // Comprobamos la magnitud de desplazamiento y aplicamos el empuje si la velocidad
        // máxima no la alcanza
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            // Aplicamos el empuje de la direccion calculada con la fuerza
            rigidbody.AddForce(moveDirection * pushForce);
        }
    }
    #endregion
}
