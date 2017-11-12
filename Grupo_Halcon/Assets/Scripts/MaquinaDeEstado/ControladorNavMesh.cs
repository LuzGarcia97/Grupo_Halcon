using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour {

    [HideInInspector]//Ocultar en el inspector.

    public NavMeshAgent NavMeshAgent;
    public Transform PosicionDelProta;
	void Awake ()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>(); //Obtengo los datos del NavMesh
	}
	
	// Update is called once per frame
	public void ActualizarPuntoDestino (Vector3 PuntoObjetivo)
    {
        NavMeshAgent.destination = PuntoObjetivo; //Le indico al NavMesh que su destino es el parametro que yo le pase.
        NavMeshAgent.isStopped = false; //Le digo que continue su recorrido.
	}

    public void DetenerRecorridaYGirar ()
    {
        NavMeshAgent.isStopped = true;
    }

    public bool LLegamos ()
    {
        //Me dice que llegue solo si la distancia que falta es menor que la que esta seteada para detenerse y que no falte mas camino por recorrer.
        return NavMeshAgent.remainingDistance <= NavMeshAgent.stoppingDistance && !NavMeshAgent.pathPending;
    }

    public void ActualizarPosicionDelJugador ()
    {
        //Recalculo el camino en base a la nueva posiscion del protagonista.
        ActualizarPuntoDestino(PosicionDelProta.position); 
    }
}
