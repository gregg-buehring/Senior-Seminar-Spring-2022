using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack_Damage : MonoBehaviour
{
   public int lives = 3;
   public int attack_damage = 1;
   public bool isDead = false;

       void Start()
       {

       }

       // Update is called once per frame
       void Update()
       {
           if(isDead){
               gameObject.SetActive(false);
           }
       }

       void OnCollisionEnter2D(Collision2D collision){
           if(collision.gameObject.tag == "Player"){
                if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Attack_Damage>().isAttacking){
                    lives-= GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Attack_Damage>().attack_damage;
                    if(lives <= 0){
                        isDead = true;
               }
            }
         }
     }
}
