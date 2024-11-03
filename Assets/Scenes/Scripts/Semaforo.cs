using System.Collections;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    public Light[] lights;
    private int currentIndex = 0;
    public float greenDuration = 5.0f, yellowDuration = 2.0f, redDuration = 5.0f;

    private void Start()
    {
        StartCoroutine(ChangeLights());
    }
    private IEnumerator ChangeLights()
    {
        while (true)
        {
            foreach (Light light in lights)
            {
                light.enabled = false;
            }
            lights[currentIndex].enabled = true;
            float duration = greenDuration;

            if (currentIndex == 1)
            {
                duration = yellowDuration;
            }else if (currentIndex == 2)
            {
                duration = redDuration;
            }
            yield return new WaitForSeconds(duration);
            currentIndex = (currentIndex + 1) % lights.Length;
        }
    }
}