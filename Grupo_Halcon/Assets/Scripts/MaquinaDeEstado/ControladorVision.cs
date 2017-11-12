using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVision : MonoBehaviour {

    public Transform Ojos;
    public float RangoDeVision = 10f;
    //variable para que la vision del rayo que sale del enemigo no mire a los pies del jugador.
    public Vector3 offset = new Vector3(0f, 1f,0f);

    private ControladorNavMesh ControladorNavMesh;
     void Awake()
    {
        ControladorNavMesh = GetComponent<ControladorNavMesh>();
    }
    public bool LoVemos(out RaycastHit hit, bool MirarAlJugador = false)
    {
        Vector3 VectorDireccion;
        if (MirarAlJugador)
        {
            //Obtengo un vestor nuevo de la resta de la posicion de los ojos y la del protagonista. Este vector me dice donde esta el protagonista.
            VectorDireccion = (ControladorNavMesh.PosicionDelProta.position + offset) - Ojos.position; 
        }
        else
        {
            // si no esta mirando al jugador, que solo mire hacia adelante.
            VectorDireccion = Ojos.forward;
        }
        //Si el rayo que lanzo desde la posicion de mi objeto ojos, a travez del eje z, colisiona con algo a menos de la distancia definida por RangoDeVision y ese objeto tiene el tag player devuelve verdadero.
        return Physics.Raycast(Ojos.position, VectorDireccion, out hit, RangoDeVision) && hit.collider.CompareTag("Player");
    }
}
