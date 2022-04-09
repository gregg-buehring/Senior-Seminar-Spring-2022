using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsScript : MonoBehaviour
{
    // need to import unityengine UI 
    [SerializeField] Text coinText;
    [SerializeField] Text hsText;
//     private GameObject coin;
    // count score
    private int scoreCount;
    public int highScore;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("CurrentCoins")){
            scoreCount = PlayerPrefs.GetInt("CurrentCoins");
        }
        else{
            scoreCount = 0;
        }

        if(PlayerPrefs.HasKey("HighScore")){
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else{
            highScore = 0;
        }

//         coin = GameObject.FindWithTag("coin");
//         coinText=GameObject.Find("coinText").GetComponent<Text>();
//         hsText=GameObject.Find("hsText").GetComponent<Text>();

        coinText.text="x"+scoreCount;
        hsText.text="High Score = "+scoreCount;
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "coin"){
            // print("he");
             
             collision.gameObject.SetActive(false);
            // add the update score and show to UI
            scoreCount++;
            coinText.text="x"+scoreCount;
            PlayerPrefs.SetInt("CurrentCoins", scoreCount);
        }
    }
}
