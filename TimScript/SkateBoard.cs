using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateBoard : MonoBehaviour
{
    Player_Movement3D playerClass;
    public GameObject player;
    private float dist;
    private Rigidbody rb;
    private float speed = 350f;
    private bool touchingGround = true;
    private float jumpForce= 500f;
    private bool jumped;
    private float timer = 0.0f;
    private int seconds;
    // Start is called before the first frame update
    void Start()
    {
          playerClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement3D>();
        rb = GetComponent<Rigidbody>();
        
       
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }
    void FixedUpdate (){
        
         dist = Vector3.Distance(player.transform.position, transform.position);
          seconds = (int)(timer%60);
         
         if(dist<=50 && seconds <5){
            timer +=Time.deltaTime;
             playerClass.BreakInput();
            SkateBoardMove();
            Playerjump();
            playerClass.FollowSkate();
            
            
        }
      }

    void SkateBoardMove(){
            float keyArrows = Input.GetAxisRaw("Horizontal"); // input from key left or right
            if(keyArrows>0){
                 rb.velocity = new Vector2(2*speed, rb.velocity.y);// the charactor moving to right(position speed), but continue hold the ypos
                   ChangeDirection(30);
                   playerClass.ChangeDirection(50);
            }
            else if (keyArrows<0){
                  rb.velocity = new Vector2(-2*speed, rb.velocity.y);
                   ChangeDirection(-30);
                   playerClass.ChangeDirection(-50);
            }
              else{
                  rb.velocity = new Vector2(0f, rb.velocity.y);
            }
      }
      void Playerjump(){ 
            
                 if(touchingGround){
                  if(Input.GetKey(KeyCode.Space) && (touchingGround)){
                       
                        jumped = true;
                        rb.velocity= new Vector2(rb.velocity.x, jumpForce);
                        touchingGround = false;
                        
                  }
                }
            }
      
       void ChangeDirection(int direction){
        //vector 3 is x, y and z
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
      }

    //checks if player is touching the ground
      void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Ground"){
            touchingGround = true;
            
            }
      }
}
