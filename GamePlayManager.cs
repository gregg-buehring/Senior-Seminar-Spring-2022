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
    private GameObject player;
    public int countdownTimer;
    private bool startTime=false;
    

    // Start is called before the first frame update
    void Awake(){
        if(instance ==null)
            instance=this;
    }
    void Start()
    {
       
       Time= GameObject.Find("Time").GetComponent<Text>();
       Clock = GameObject.Find("Clock").GetComponent<Image>();
       Clock.enabled=false;
       Time.enabled=false;
    }
    void Update(){
       
         if(startTime){
            Time.text=countdownTimer.ToString();
            StartCoroutine("CountDown");
            startTime=false;
        }
    }
    IEnumerator CountDown(){

        yield return new WaitForSeconds(1f);
        countdownTimer-=1;

        Time.text=countdownTimer.ToString();
        StartCoroutine("CountDown");
        if(countdownTimer<=0){
            StopCoroutine("CountDown");
            Time.enabled=false;
            Clock.enabled=false;

        }
        
    }

      // touch the bottom ground and triger the time
     void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "BottomGround"){
            startTime=true;
            Time.enabled=true;
            Clock.enabled=true;
            
        }
    }

}
