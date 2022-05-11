using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAdvancedGUI : MonoBehaviour
{
    
    float rgbValue = 0.5f;

    void OnGUI()
    {

        rgbValue = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 50, 90, 100, 30), rgbValue, 0f, 1.0f);
        RenderSettings.ambientLight = new Color(rgbValue, rgbValue, rgbValue, 1);

        if (GUI.Button(new Rect(Screen.width / 2 - 80, 30, 160, 30), "minValue"))
        {
            rgbValue = 0f;
        }

    }

}
