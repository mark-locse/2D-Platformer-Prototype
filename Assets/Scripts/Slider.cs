using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    /// Declaring and referencing required objects
    public UnityEngine.UI.Slider slider;
    public GameObject Handle;
    public GameObject HandleText;
    public TMP_Text TextContent;
    public AudioSource audioSource;
    private readonly float y_offset = 25f; // offset to visually separate the text from the slider handle

    // Update is called once per frame
    void Update()
    {
        Vector3 HandlePosition = Handle.transform.position; //store Handle's coordinates
        HandleText.transform.position = new Vector3(HandlePosition.x, HandlePosition.y + y_offset, HandlePosition.z); 
        TextContent.text = ((slider.value / slider.maxValue) * 100).ToString();
        audioSource.volume = slider.value / slider.maxValue;
        //Updates the Text object's co-ordinates with the handle and updates contents accordingly
    }
}