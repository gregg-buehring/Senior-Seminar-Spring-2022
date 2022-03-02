using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement3D : MonoBehaviour
{
      public int speed = 25;
      private Rigidbody rb;
      private float jumpForce = 350f;
      private int gravitymodifier = 20;
      public bool touchingGround = true;
      private bool jumped;
      private bool isGround;
      private float h;
      public static bool IsInputEnabled;
      public GameObject skateBoard;
      
      
      

      void Start(){
        rb = GetComponent<Rigidbody>();
        IsInputEnabled= true;
      }

      void Update() {
            MovePlayer();
            Playerjump();
          
            
            


      }
      
      void MovePlayer(){

            if((Input.GetKeyDown(KeyCode.W))&&(touchingGround)){
                  rb.AddForce(Vector2.up * 5* jumpForce, ForceMode.Impulse);
                  touchingGround = false;
            }
           
            else if(Input.GetKey(KeyCode.A)){
                  transform.position = new Vector3(transform.position.x-Time.deltaTime*speed,transform.position.y,transform.position.z);
            }
           
          
            else if(Input.GetKey(KeyCode.D)){
                  transform.position = new Vector3(transform.position.x+Time.deltaTime*speed,transform.position.y,transform.position.z);
            }

            // //gravity
            // if(!touchingGround){
            //       transform.Translate(Physics.gravity * gravitymodifier * Time.deltaTime);
            // }
      }

      // Tim modify the walf function 
      // Update frame every 0.02 s (every fixed time we update)
      void FixedUpdate (){
            
            PlayerWalk();
      }

      

      void PlayerWalk(){
             h = Input.GetAxisRaw("Horizontal"); // input from key left or right
            if(h>0 && IsInputEnabled){
                 rb.velocity = new Vector2(2*speed, rb.velocity.y);// the charactor moving to right(position speed), but continue hold the ypos
                   ChangeDirection(50);  
            }
            else if (h<0 && IsInputEnabled){
                  rb.velocity = new Vector2(-2*speed, rb.velocity.y);
                  ChangeDirection(-50);
            }
            
              else{
                  rb.velocity = new Vector2(0f, rb.velocity.y);
            }
      }
      // method to disable the input arrow keys when the player on the skateboard 
      public void BreakInput(){
                IsInputEnabled = true;  
            
            
        
      }
      // fucntion to make the player follow the skateboard 
      public void FollowSkate(){
                  transform.position= Vector3.MoveTowards(transform.position, skateBoard.transform.position, 350f);
            
            
            
            
            
      }

      public void ChangeDirection(int direction){
        //vector 3 is x, y and z
        Vector3 tempScale = transform.localScale;
        tempScale.z = direction;
        transform.localScale = tempScale;
      }
      
      // function for jump movement after pressing the space key
      void Playerjump(){ 
            if(touchingGround){
                  if(Input.GetKey(KeyCode.Space) && (touchingGround)){
                       
                        jumped = true;
                        rb.velocity= new Vector2(rb.velocity.x, jumpForce);
                        touchingGround = false;
                        
                  }
            }
      }

        //checks if player is touching the ground
      void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Ground"){
            touchingGround = true;
            gravitymodifier = 1;
            }
      }

      // 
     
}