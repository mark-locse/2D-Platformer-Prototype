using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    /// Referencing all my Audio Objects and linking them to Audio Source objects
    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("----------- Audio Clip -----------")]
    public AudioClip BGM;
    public AudioClip death;
    public AudioClip checkpoint;
    public AudioClip coin;
    public AudioClip jump;

    private void Start() //Updates on the first frame
    {
        musicSource.clip = BGM;
        musicSource.Play();
        musicSource.volume = 0.5f;
        SFXSource.volume = 0.5f;
    }

    public void playSFX(AudioClip clip) //This function lets different sound effects to be played.
    {
        SFXSource.PlayOneShot(clip);
    }
}
