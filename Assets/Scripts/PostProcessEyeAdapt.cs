using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProcessEyeAdapt : MonoBehaviour
{
    PostProcessVolume volume;
    AutoExposure autoExposure = null;
    bool isActive = true;
    private void Awake()
    {
        volume = GetComponent<PostProcessVolume>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (isActive)
        {
            volume.profile.TryGetSettings(out autoExposure);

            autoExposure.minLuminance.value = -7;
            autoExposure.maxLuminance.value = -7;

            Invoke("ReturnState", 2f);
            isActive = false;
        }
   
    }

    private void ReturnState()
    {
        autoExposure.minLuminance.value = 0.19f;
        autoExposure.maxLuminance.value = 0.27f;
    }
}
