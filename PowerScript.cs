using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerScript : MonoBehaviour
{
    private Rigidbody rb;
    private int jumpForce=500;
    private bool push;
    private GameObject power;
    // Start is called before the first frame update
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody>();
        power = GameObject.FindWithTag("PowerPush");
    }

     // hit the push power
     void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "PowerPush"){
                  jumpForce = jumpForce*3;
                 rb.velocity= new Vector2(rb.velocity.x, jumpForce);
                 jumpForce =jumpForce/3;
                  Destroy(collision.gameObject);
        }
    }
}
