
///////////////////////////////
// Practica: SaladilloVR
// Alumno/a: Laura Calvente Domínguez
// Curso: 2017/2018
// Fichero: CustomPointer.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomPointerTimer : MonoBehaviour {

    #region Variables
    // Objeto compartido por todos los scripts
    public static CustomPointerTimer CPT;
    // Tiempo por defecto que vamos a tener que espera para que el contador se rellene
    private float timeToWait = 3f;
    // Temporizador
    private float timer = 0f;
    // componente Image de la image de relleno
    private Image imagen;
    // Indica cuando esta contando
    [HideInInspector]
    public bool countring = false;
    // Indica si ha llegado al final
    [HideInInspector]
    public bool ended = false;
    #endregion

    #region Metodos
    /// <summary>
    /// Comprobamos que el CPT esta inicializado antes de que se haga el Start.
    /// Asignamos la imagen.
    /// </summary>
    private void Awake()
    {
        if (CPT == null)
        {
            // Se obtiene el objeto temporizador
            CPT = GetComponent<CustomPointerTimer>();
        }
        // Se obtiene la imagen del reloj
        imagen = GetComponentInChildren<Image>();

    }

    /// <summary>
    /// Tratamos la imagen.
    /// </summary>
    void Update()
    {
        if (countring)
        {
            //Se incrementa el temporizador la porcion de tiempo
            // que ha tardado em rederizar el ultimo update. De esta
            //manera se tiene un control de tiempo real independientemente
            // de las carsteriticas de maquina
            timer += Time.deltaTime;
            // Se rellena la imagem ña camtidad proporcional al temporizador
            imagen.fillAmount = timer / timeToWait;

        }
        else
        {   // se reinicia el temporizador
            timer = 0f;
            // Se reinicia el relleno
            imagen.fillAmount = timer;
        }
        // Se comprueba si ha cumplido el tiempo de espera
        if (timer >= timeToWait)
        {
            // se indica que el contador ha finalizado
            ended = true;
        }


    }
    /// <summary>
    /// Inicia el temporizador, utilizando el tiempo indicado	como parametro
    /// </summary>
    /// <param name="time"></param>
    public void StartCounting(float time)
    {
        countring = true;
        ended = false;
        timeToWait = time;
    }

    public void StopCounting()
    {
        countring = false;
        ended = true;
    }
    #endregion
}
