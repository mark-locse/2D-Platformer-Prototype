using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //declare required variables
    public Transform player;
    public Vector3 offset;
    void LateUpdate() //Changes the camera position to that of the player
    {
        transform.position = player.position + offset;
    }
}
