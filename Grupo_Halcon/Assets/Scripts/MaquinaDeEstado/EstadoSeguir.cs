using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoSeguir : MonoBehaviour {

    Color ColorEstado = Color.red;
    private CentralMaquina MaquinaDeEstados;
    private ControladorNavMesh ControladorNavMesh;
    private ControladorVision ControladorVision;
	void Awake ()
    {
        MaquinaDeEstados = GetComponent<CentralMaquina>();
        ControladorNavMesh = GetComponent<ControladorNavMesh>();
        ControladorVision = GetComponent<ControladorVision>();
	}

    // Update is called once per frame
    private void OnEnable()
    {
        MaquinaDeEstados.Indicador.material.color = ColorEstado;
    }
    void Update ()
    {
        RaycastHit hit;
        if (!ControladorVision.LoVemos(out hit, true))
        {
            MaquinaDeEstados.ActivarUnEstado(MaquinaDeEstados.EstadoAtaque);
            return;
        }
        ControladorNavMesh.ActualizarPuntoDestino(ControladorNavMesh.PosicionDelProta.position);

	}
}
