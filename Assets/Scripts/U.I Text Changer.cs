using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    // Objects from the game engine are referenced here to be used in the code
    public PlayerCollisions PlayerCollisions;
    public TMP_Text TimerText;
    public TMP_Text DeathText;
    public TMP_Text CoinText;
    public TMP_Text FinalTimer;
    public TMP_Text FinalDeath;
    public TMP_Text FinalCoin;
    public string CoinTag = "Coin";
    private float duration = 0f;
    private GameObject[] TotalCoins;

   //Function that updates only on the first frame.
    private void Start()
    {
        TotalCoins = GameObject.FindGameObjectsWithTag(CoinTag);
    }
    //Function that updates every frame
    private void Update()
    {
        duration += Time.deltaTime; //variable for time elapsed is incremented with time passing

        //code to get minutes and seconds, then store them into variables
        int minutes = Mathf.FloorToInt(duration / 60);
        int seconds = Mathf.FloorToInt(duration % 60);


        //The values are printed out as text
        TimerText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");

        // Text for the amount of Deaths and Coins the player has is updated here
        DeathText.text = PlayerCollisions.DeathCount.ToString();
        CoinText.text = PlayerCollisions.CoinCount.ToString() + "/" + TotalCoins.Length.ToString();
        FinalTimer.text = TimerText.text;
        FinalDeath.text = DeathText.text;
        FinalCoin.text = CoinText.text;
    }
}
