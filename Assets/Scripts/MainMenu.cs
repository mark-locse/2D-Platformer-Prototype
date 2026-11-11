using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   //These two functions are used within the engine itself, PlayGame() for loading the scene the game is in and QuitGame() for exiting the program
    public void Level1()
    {
        SceneManager.LoadSceneAsync(1); //This built-in function changes the scene the program is showing "1" being the value the game scene is stored in
    }
    public void Level2()
    {
        SceneManager.LoadSceneAsync(2); //This built-in function changes the scene the program is showing "1" being the value the game scene is stored in
    }
    public void Level3()
    {
        SceneManager.LoadSceneAsync(3); //This built-in function changes the scene the program is showing "1" being the value the game scene is stored in
    }
    public void QuitGame()
    {
        Application.Quit(); //This built-in function stops the program from running
    }
}
