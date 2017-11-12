using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour {

	NavMeshAgent NV;
	//Variable que declara a donde se va a mover el personaje
	Vector3 Objetivo;
    public float DistanciaY;
    public float DistanciaZ;
	void Start () 
	{
		//Declaro que voy a usar NavMesh
		NV = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		//Si se hace click se guarda la posicion del click
		if (Input.GetMouseButtonDown (0))
		{
			Ray Rayo = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit Posicion;

			if(Physics.Raycast(Rayo, out Posicion))
			{
				//Posicion.point nos da el lugar exacto donde el rayo choco.
				Objetivo = Posicion.point;
				SetearPosicion ();
			}
		}
	}

	void SetearPosicion()
	{
		NV.SetDestination (Objetivo);
	}
}
