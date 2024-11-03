using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRandom : MonoBehaviour
{
    public Light focoLight;
    public float encendidoDuration = 2.0f;
    public int cantidadParpadeos = 5;
    public float parpadeoIntervalo = 0.5f;

    private void Start()
    {
        // Encender la luz del foco por 2 segundos
        focoLight.enabled = true;
        Invoke("IniciarParpadeo", encendidoDuration);
    }

    private void IniciarParpadeo()
    {
        // Parpadear un número aleatorio de veces
        for (int i = 0; i < cantidadParpadeos; i++)
        {
            Invoke("ParpadearFoco", i * parpadeoIntervalo);
        }
    }

    private void ParpadearFoco()
    {
        // Alternar entre encender y apagar la luz del foco
        focoLight.enabled = !focoLight.enabled;
    }
}