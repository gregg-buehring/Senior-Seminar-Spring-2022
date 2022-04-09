using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rb;
    [SerializeField] Player_Movement3D move;
    private bool isFalling = false;
    private bool touchingGround = true;
    // Update is called once per frame
    void Update()
    {
        isFalling = false;
        touchingGround = move.touchingGround;
        if(falling()){
            isFalling = true;
        }

        if((Input.GetKey(KeyCode.A))||(Input.GetKey(KeyCode.D))){
            anim.SetTrigger("Walking");
        }
        if((Input.GetKeyDown(KeyCode.W))&&(touchingGround)){
            anim.SetTrigger("Jumping");
        }
        if(isFalling){
            anim.SetTrigger("Falling");
        }
        if(touchingGround){
            anim.SetTrigger("Grounded");
        }
    }

    bool falling(){
        if(rb.velocity.y < -0.01){
            return true;
        }
            return false;
    }
}
