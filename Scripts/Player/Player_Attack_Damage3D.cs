using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack_Damage3D : MonoBehaviour
{
   public int lives = 3;
       public int attack_damage = 1;
       public bool isDead = false;
       public bool isAttacking = false;
       [SerializeField] GameObject GameOver;
       [SerializeField] AudioSource attack;
       [SerializeField] AudioSource injured;
       [SerializeField] AudioSource death;

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
                   attack.Play();
               }
               else{
                   isAttacking = false;
               }
           }
       }

       void OnCollisionEnter(Collision collision){
           if((collision.gameObject.tag == "Enemy")&&(!isAttacking)){
               injured.Play();
               lives-=GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy_Attack_Damage3D>().attack_damage;
               if(lives == 0){
                   isDead = true;
               }
            }
         }

       void gameOver(){
           death.Play();
           GameOver.active = true;
           gameObject.GetComponent<Player_Movement3D>().speed = 0;
       }
}
