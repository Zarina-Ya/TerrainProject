using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProcessBoiler : MonoBehaviour
{
    PostProcessVolume processVolume;

    ChromaticAberration chromatic = null;
    void Awake()
    {
       
        processVolume = GetComponent<PostProcessVolume>();
    }

    private void OnTriggerEnter(Collider other)
    {
        processVolume.profile.TryGetSettings(out chromatic);

        chromatic.enabled.value = true;
        chromatic.intensity.value = 1f;

        Invoke("ReturnState", 5f);
    }


    public void ReturnState()
    {
        chromatic.enabled.value = false;
    }
}
