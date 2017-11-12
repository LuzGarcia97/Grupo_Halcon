using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralMaquina : MonoBehaviour {

    public MonoBehaviour EstadoPatrulla;
    public MonoBehaviour EstadoAtaque;
    public MonoBehaviour EstadoSeguir;
    public MonoBehaviour EstadoInicial;
    private MonoBehaviour EstadoActual;

    public MeshRenderer Indicador;

	void Start ()
    {
        ActivarUnEstado(EstadoInicial);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Para activar un estado tengo que desactivar el estado actual.
    public void ActivarUnEstado (MonoBehaviour NuevoEstado)
    {
        if (EstadoActual != null)
        EstadoActual.enabled = false; // El estado actual se desactivo.
        EstadoActual = NuevoEstado; //Le asigno al estado actual el estado que quiero activar.
        EstadoActual.enabled = true; // Vuelvo a activar estadoactual.
    }
}
