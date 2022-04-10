using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    // need to import unityengine UI 
    private Text coinText;
    private GameObject coin;
    // count score
    private int scoreCount;
    // Start is called before the first frame update
    void Start() {
        coin = GameObject.FindWithTag("Coin");
        coinText = GameObject.Find("CoinCount").GetComponent<Text>();
        scoreCount = 0;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Coin") {

            // add the update score and show to UI
            scoreCount = scoreCount + 1;
            coinText.text = "x" + scoreCount;

            Destroy(collision.gameObject);
        }
    }
}
