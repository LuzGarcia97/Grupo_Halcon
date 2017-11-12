using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAtaque : MonoBehaviour {

    private CentralMaquina MaquinaDeEstados;
    public Color ColorEstado = Color.yellow;
    private ControladorNavMesh ControladorNavMesh;
    public float TiempoDeBusqueda = 5f;
    public float VelocidadAlGirar = 120f;
    public float TiempoBuscando;
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
        ControladorNavMesh.DetenerRecorridaYGirar();
        TiempoBuscando = 0f;
    }

    void Update ()
    {
        transform.Rotate(0f, VelocidadAlGirar * Time.deltaTime,0f);
        TiempoBuscando += Time.deltaTime;

        RaycastHit hit;
        //hit va a tener el valor que me mande el metodo lo vemos.
        if (ControladorVision.LoVemos(out hit))
        {
            ControladorNavMesh.PosicionDelProta = hit.transform;
            MaquinaDeEstados.ActivarUnEstado(MaquinaDeEstados.EstadoSeguir);
            return;
        }

        if (TiempoBuscando >= TiempoDeBusqueda)
        {
            MaquinaDeEstados.ActivarUnEstado(MaquinaDeEstados.EstadoPatrulla);
            return;
        }
    }

   
}
