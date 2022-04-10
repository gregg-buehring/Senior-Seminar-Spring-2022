using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;
    [SerializeField]
    private Text Time;
    private Image Clock;
    private Text GameOverText;
    private GameObject player;
    public int countdownTimer;
    private bool startTime=false;
    private int countTouch=0;
    

    // Start is called before the first frame update
    void Awake(){
        if(instance ==null)
            instance=this;
    }
    void Start()
    {
       Time= GameObject.Find("Time").GetComponent<Text>();
       Clock = GameObject.Find("Clock").GetComponent<Image>();
       GameOverText=GameObject.Find("GameOverText").GetComponent<Text>();
       GameOverText.enabled=false;
       Clock.enabled=false;
       Time.enabled=false;
    }
    void Update(){
       if(countTouch==1){
           if(startTime){
            Time.text=countdownTimer.ToString();
            StartCoroutine("CountDown");
            startTime=false;
           }
       }   
    }
    IEnumerator CountDown(){
        yield return new WaitForSeconds(1f);// count down per second 
        countdownTimer-=1;
        Time.text=countdownTimer.ToString();// update the timer into the UI 
        StartCoroutine("CountDown");
        if(countdownTimer<=0){
            StopCoroutine("CountDown");
            // Timer disappear
            Time.enabled=false;
            Clock.enabled=false;
            GameOverText.enabled=true;// show the "Game Over" text. 
        }   
    }
      // touch the bottom ground and triger the time
     void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "BottomGround"){
            startTime=true;
            countTouch++; // count how many time the player touch the ground. 
            // show the Timer
            Time.enabled=true;
            Clock.enabled=true;
        }
    }
}
