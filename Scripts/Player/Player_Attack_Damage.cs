using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack_Damage : MonoBehaviour
{
    public int lives = 3;
    public int attack_damage = 1;
    public bool isDead = false;
    public bool isAttacking = false;
    [SerializeField] GameObject GameOver;

    void Start()
    {
        GameOver = GameObject.FindGameObjectWithTag("Game Over");
        GameOver.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){
            gameOver();
        }
        else{
            if(Input.GetKey(KeyCode.F)){
                isAttacking = true;
            }
            else{
                isAttacking = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if((collision.gameObject.tag == "Enemy")&&(!isAttacking)){
            lives-=GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy_Attack_Damage>().attack_damage;
            if(lives == 0){
                isDead = true;
            }
         }
      }

    void gameOver(){
        GameOver.active = true;
        gameObject.GetComponent<Player_Movement>().speed = new Vector2(0,0);
    }
}
