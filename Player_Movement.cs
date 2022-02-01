using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Movement : MonoBehaviour{

  public Vector2 speed = new Vector2(25,25);
  public Rigidbody2D rb;
  public int jumpForce = 20;
  public int gravitymodifier = 1;
  public bool touchingGround = true;

  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }

  void Update() {
  if((Input.GetKeyDown(KeyCode.W))&&(touchingGround)){
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        touchingGround = false;
  }
  if(Input.GetKey(KeyCode.A)){
        transform.Translate(Vector3.left * Time.deltaTime * speed);
  }
  if(Input.GetKey(KeyCode.S)){
     if(!touchingGround){
         gravitymodifier = 2;
     }
  }
  if(Input.GetKey(KeyCode.D)){
        transform.Translate(Vector3.right * Time.deltaTime * speed);
  }

  //gravity
  if(!touchingGround){
     transform.Translate(Physics2D.gravity * gravitymodifier * Time.deltaTime);
  }

  }

    //checks if player is touching the ground
  void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.tag == "Ground"){
        touchingGround = true;
        gravitymodifier = 1;
        }
  }

//   void OnCollisionExit2D(Collision2D collision){
//     if(collision.gameObject.tag == "Ground"){
//        touchingGround = false;
//        }
//   }
}
