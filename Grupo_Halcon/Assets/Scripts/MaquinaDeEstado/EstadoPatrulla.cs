using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrulla : MonoBehaviour {

	public Transform[] WayPoints;
    public int SiguientePunto;
    private ControladorNavMesh ControladorNavMesh;
    private CentralMaquina MaquinaDeEstados;
    private ControladorVision ControladorVision;
    public Color ColorDelEstado = Color.cyan;

	void Awake ()
    {
        ControladorNavMesh = GetComponent<ControladorNavMesh>();
        MaquinaDeEstados = GetComponent<CentralMaquina>();
        ControladorVision = GetComponent<ControladorVision>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ControladorNavMesh.LLegamos())
        {
            //Lo que hace es dividir la cantidad de puntos recorridos por los puntos en total, asi al llegar al final de los puntos totales se dividira por el mismo numero, va a dar cero y va a empezar otra vez.
            SiguientePunto = (SiguientePunto + 1) % WayPoints.Length;
            ActualizarDestino();
        }
        RaycastHit hit;
        //hit va a tener el valor que me mande el metodo lo vemos.
        if(ControladorVision.LoVemos(out hit))
        {
            ControladorNavMesh.PosicionDelProta = hit.transform;
            MaquinaDeEstados.ActivarUnEstado(MaquinaDeEstados.EstadoSeguir);
            return;
        }
	}
    //OnEnable actua cada vez que el scrip se activa
    private void OnEnable()

    {
        ActualizarDestino();
        MaquinaDeEstados.Indicador.material.color = ColorDelEstado;
    }
    

    void ActualizarDestino()
    {
        //Le digo al controlador que se mueva a la posicion del waypoint que hago referencia.
        ControladorNavMesh.ActualizarPuntoDestino(WayPoints[SiguientePunto].position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enabled)
        {
            MaquinaDeEstados.ActivarUnEstado(MaquinaDeEstados.EstadoAtaque);
        }
    }
}
