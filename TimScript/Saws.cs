using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saws : MonoBehaviour
{
    public float amp=425;
    public float speed =100;
    public float yStart = 500f;
    public GameObject player;
    private float dist;
    public float xposition;
    private static float zPosition=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SawMove();
        SawCollision();
    }
    // move the saw up and down
    void SawMove(){
        float yPosition = yStart+Mathf.Sin(Time.time*speed)*amp;
        
        transform.position = new Vector3(xposition,yPosition , zPosition);
    }
    
    // check if the player colide the saw and di
     void SawCollision(){
            dist = Vector3.Distance(transform.position, player.transform.position);
            if(dist<80){
                  player.SetActive(false);
            }
      }
}
