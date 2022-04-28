using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saws : MonoBehaviour
{
    public float amp;
    public float speed;
    public float yStart;
    public GameObject player;
    private float dist;
    public float xPosition;
    public float zPosition;
    public float zScaleStart;
    public bool isSaw;
    

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
        float zScale = zScaleStart + Mathf.Sin(Time.time*speed)*amp;
        transform.position = new Vector3(xPosition,yPosition , zPosition);
        if(isSaw){
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zScale );
        }
        
    }
    
    // check if the player colide the saw and di
     void SawCollision(){
            dist = Vector3.Distance(transform.position, player.transform.position);
            if(dist<80){
                  player.SetActive(false);
            }
      }
}
