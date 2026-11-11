using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TurboToggle : MonoBehaviour
{
    public static bool isTurbo = false;
    public static bool isSnail = false;
    public UnityEngine.UI.Toggle turboToggle;
    public UnityEngine.UI.Toggle snailToggle;

    // Update is called once per frame
    void Update()
    {
       if (turboToggle.isOn)
        {
            isTurbo = true;
        }
        else
        {
            isTurbo = false;
        }
       if (snailToggle.isOn)
        {
            isSnail = true;
        }
       else
        {
            isSnail = false;
        }
    }
}
