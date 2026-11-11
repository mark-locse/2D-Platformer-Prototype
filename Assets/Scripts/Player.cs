using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour //Creates the class the script is inside of, which will link it with the game engine.
{
    public float speed = 5; //The speed variable is declared here. This determines the default speed of the player when moving.
    public Rigidbody2D rb; //rb is declared and used to refer to the RigidBody2D assigned to the playable character within the game engine.
    public float jumpStrength = 5; //jumpStrength is declared and used to determine the default jump force of the player.
    private bool isGrounded = false; // isGrounded is declared and used to check whether the player character is currently on the ground or not.
    public GameObject canvasMain;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public TurboToggle TurboToggle;
    private bool isPaused = false;
    public PlayerCollisions PlayerCollisions;
    AudioManager audioManager;

    private void Start() //Bugfixes timescale issues from entering other levels
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is a built-in function that is called once per frame. This allows the program, in this case the game, to constantly run unless otherwise stated.
    void Update()
    {
        rb.freezeRotation = true;
        Movement(isGrounded, isPaused); //Calls the function Movement() to be able to give the player its respective movement
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && !OptionsMenu.activeSelf)
        {
            Pause();
        }
            
    }

    void Movement(bool isGrounded, bool isPaused)
    {
            // Declares the horiz variable that then has the horizontal co-ordinates of the player.
            // The built-in function Input.GetAxis() is used to detect horizontal movement based on the user’s input.
            float horiz = Input.GetAxis("Horizontal");
            Vector2 pos = transform.position; //Declares the variable pos, sets it under Vector2, and uses the built-in function “transform.position” to store the coordinates of the player

            //Changes the horizontal or vertical co-ordinates of the player character
            pos.x += horiz * speed * Time.deltaTime;

            //this if statement works with the built-in function Input.GetKey() to change the vertical position of the player when either the W or Up Arrow keys are pressed
            if ((Input.GetKeyDown(KeyCode.W) ^ Input.GetKeyDown(KeyCode.UpArrow) ^ Input.GetKeyDown(KeyCode.Space)) && isGrounded && !isPaused)
            {
                audioManager.playSFX(audioManager.jump);
            
                //A force is applied to the body of the player character using the built-in function AddForce()
                rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            }

            transform.position = pos; //This allows the new co-ordinates of the player to be stored
        
    }
    
    //For both of the following functions, and if statement is used to set the player's "grounded" state to true or false depending on their collision with the floor
    private void OnCollisionEnter2D(UnityEngine.Collision2D other) //The function OncollisionEnter2D() is used here to allow something to happen when the player's body collides with the floor
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }
    private void OnCollisionExit2D(UnityEngine.Collision2D other) //The function OncollisionExit2D() is used here to allow something to happen when the player's body stops colliding with the floor
    {
        if (other.gameObject.CompareTag("Ground"))
        { 
            isGrounded = false; 
        }
            
    }
    public void Pause()
    {
        if (!isPaused && !PlayerCollisions.isCompleted) //checking if the game is unpaused
        {
            //this displays the pause menu
            PauseMenu.SetActive(true);
            Time.timeScale = 0; //the character is frozen
            isPaused = true; //the game is set as Paused
        }
        else if (isPaused && !PlayerCollisions.isCompleted) //checking if the game is paused
        {
            //this stops displaying the pause menu
            PauseMenu.SetActive(false);
            if (TurboToggle.isTurbo && !TurboToggle.isSnail) //the character is unfrozen
            {
                Time.timeScale = 2;
            }
            else if (TurboToggle.isSnail && !TurboToggle.isTurbo)
            {
                Time.timeScale = 0.5f;
            }
            else if (TurboToggle.isTurbo && TurboToggle.isSnail)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 1;
            }
            isPaused = false; //the game is set as Unpaused
        }
    }
}


