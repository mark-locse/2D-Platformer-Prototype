using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// This is a script for manipulating the state the Checkpoint is in
public class CheckpointFlag : MonoBehaviour
{
    public bool isActivated = false;
    public void StartResetTimer()
    {
        StartCoroutine(ResetState());
    }
    private IEnumerator ResetState() //A type of function that allows the pausing of the script
    {
        yield return new WaitForSeconds(10);
        isActivated = false;
    }

}
