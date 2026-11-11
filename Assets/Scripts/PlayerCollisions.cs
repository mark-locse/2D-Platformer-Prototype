using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject MainCharacter;
    public GameObject MainCanvas;
    public GameObject CompletionMenu;
    public GameObject HUD;
    public GameObject RedGate;
    public GameObject DeathlessGate;
    public TMP_Text DifficultyText;
    private UnityEngine.Vector2 StartPos;
    public int CoinCount = 0;
    public int DeathCount = 0;
    public bool isCompleted = false;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        StartPos = MainCharacter.transform.position;
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike")) //"kills" the player when they collide with a spike by resetting their co-ordinates
        {
            audioManager.playSFX(audioManager.death);
            MainCharacter.transform.position = StartPos;
            DeathCount += 1;
            print("Death Count:" + DeathCount);
            DeathlessGate.SetActive(true);
        }
        
        /// These are tied to the difficulty blocks that make barriers appear/disappear
        if (collision.gameObject.CompareTag("Green")) 
        {
            RedGate.SetActive(true);
            DifficultyText.text = "Difficulty: Easy";
            DifficultyText.color = Color.green;
        }
        if (collision.gameObject.CompareTag("Red"))
        {
            RedGate.SetActive(false);
            DifficultyText.text = "Difficulty: Hard";
            DifficultyText.color = Color.red;
        }

    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin")) // This if statement makes the coin disappear on collision, and adds to the coin counter variable.
        {
            audioManager.playSFX(audioManager.coin);
            Destroy(collision.gameObject);
            CoinCount += 1;
            print("Coin Count:" + CoinCount);
        }
        if (collision.gameObject.CompareTag("CheckpointFlag"))
        {
            //Gets the individual Checkpoint Flag object
            CheckpointFlag checkpoint = collision.gameObject.GetComponent<CheckpointFlag>();
            if ( checkpoint != null && !checkpoint.isActivated)
            {
                audioManager.playSFX(audioManager.checkpoint);
                // Set the respawn point to the co-ordinates of that flag
                StartPos = collision.gameObject.transform.position;
                Debug.Log("Colliding with checkpoint, spawn updated.");
                //Change the state of the flag and start a timer to reset its state
                checkpoint.isActivated = true;
                checkpoint.StartResetTimer();
            }
            
        }
        if (collision.gameObject.CompareTag("CompletionFlag"))
        {
            // make the level completion menu show up.
            isCompleted = true;
            Time.timeScale = 0;
            MainCanvas.SetActive(true);
            CompletionMenu.SetActive(true);
            HUD.SetActive(false);
        }
    }
}

