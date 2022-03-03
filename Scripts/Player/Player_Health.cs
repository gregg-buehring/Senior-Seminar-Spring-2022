using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
     public int lives = 3;
     public int attack_damage = 1;
     public bool isDead = false;
     [SerializeField] AudioSource injured;
     [SerializeField] AudioSource death;
    // Start is called before the first frame update

    private Player_Attack attack;
    void Start()
    {
        attack = GetComponent<Player_Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){
            gameOver();
        }
    }

    void OnCollisionEnter(Collision collision){
        if((collision.gameObject.tag == "Enemy")&&(attack.isAttacking)){
            injured.Play();
            lives-=GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy_Attack_Damage3D>().attack_damage;
            if(lives == 0){
                isDead = true;
            }
        }
   }
   void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Heart"){
            lives++;
        }
  }

   void gameOver(){
        death.Play();
        gameObject.GetComponent<Player_Movement3D>().speed = 0;
    }
}
