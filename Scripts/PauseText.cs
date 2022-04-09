using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseText : MonoBehaviour
{
    public bool isResume;
    public bool isQuit;

    [SerializeField] GameObject pause;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseUp(){
       if(isResume){
            pause.GetComponent<Pause>().UnpauseGame();
        }
        if (isQuit){
        	PlayerPrefs.SetInt("HighScore", player.GetComponent<coinsScript>().highScore);
        	PlayerPrefs.SetInt("CurrentCoins", 0);
        	Application.Quit();
        }
    }
}
