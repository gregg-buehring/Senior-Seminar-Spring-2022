using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement3D : MonoBehaviour
{
    public int speed = 25;
      public Rigidbody rb;
      public int jumpForce = 20;
      public int gravitymodifier = 1;
      public bool touchingGround = true;

      void Start(){
        rb = GetComponent<Rigidbody>();
      }

      void Update() {
      if((Input.GetKeyDown(KeyCode.W))&&(touchingGround)){
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            touchingGround = false;
      }
      if(Input.GetKey(KeyCode.A)){
            transform.position = new Vector3(transform.position.x-Time.deltaTime*speed,transform.position.y,transform.position.z);
      }
      if(Input.GetKey(KeyCode.S)){
         if(!touchingGround){
             gravitymodifier = 2;
         }
      }
      if(Input.GetKey(KeyCode.D)){
            transform.position = new Vector3(transform.position.x+Time.deltaTime*speed,transform.position.y,transform.position.z);
      }

      //gravity
      if(!touchingGround){
         transform.Translate(Physics.gravity * gravitymodifier * Time.deltaTime);
      }

      }

        //checks if player is touching the ground
      void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Ground"){
            touchingGround = true;
            gravitymodifier = 1;
            }
      }
}
