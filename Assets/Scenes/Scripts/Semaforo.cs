using System.Collections;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    public Light[] lights;
    public float delay = 1.0f;

    private void Start()
    {
        StartCoroutine(ChangedLightRandom());
    }
    IEnumerator ChangedLightRandom()
    {

        int index = Random.Range(0, lights.Length);
        OffAllLight();
        lights[index].enabled = true;
        yield return new WaitForSeconds(delay);
    }
    private void OffAllLight()
    {
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }
}
