using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_Attack : MonoBehaviour {
    public int lives = 3;
    public int attack_damage = 1;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isDead) {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Attack_Damage3D>().isAttacking) {
                lives -= GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Attack_Damage3D>().attack_damage;
                if (lives <= 0) {
                    isDead = true;
                }
            }
            
            //For Noel
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Attack>().isAttacking) {
                lives -= GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Attack>().attack_damage;
                if (lives <= 0) {
                    isDead = true;
                }
            }
        }
    }
}
