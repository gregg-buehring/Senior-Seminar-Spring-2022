using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderFall : MonoBehaviour
{
    public float amp=425;
    public float speed =100;
    public float yStart = 500f;
    public GameObject player;
    private float dist;
    public float xPosition;
    public float zPosition;
    public float yScaleStart;
    public bool isSave;
    public bool scaleChange;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpiderMove();
        SpiderCollision();
    }
    // move the spider up and down
    void SpiderMove(){
        float yPosition = yStart+Mathf.Sin(Time.time*speed)*amp;
        float yScale = yScaleStart + Mathf.Sin(Time.time*speed)*amp;
        transform.position = new Vector3(xPosition,yPosition , zPosition);
        if(scaleChange){
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yScale, transform.eulerAngles.z );
        }
        
        
    }
    
    // check if the player colide the saw and di
     void SpiderCollision(){
            dist = Vector3.Distance(transform.position, player.transform.position);
            if(dist<100 && isSave == false){
                  player.SetActive(false);
            }
      }
}
