using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public int attack_damage = 1;
    public bool isAttacking = false;
    public int bulletCount = 0;
    [SerializeField] AudioSource attack;

    //Variable to keep track of when the next shot can be taken
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] lazers;
    private float attackTimeCooldown = Mathf.Infinity;

    //Grab a reference to the player's movement script
    private Player_Movement3D playerMovements;

    private void Awake(){
        playerMovements = GetComponent<Player_Movement3D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F)){
            isAttacking = true;
            attack.Play();
        }
        else{
            isAttacking = false;
        }

       if((Input.GetMouseButtonDown(0)&&(attackTimeCooldown>attackCooldown)&&(bulletCount>0))){
            Shoot();
            attackTimeCooldown += Time.deltaTime;
            bulletCount--;
       }
    }

    private void Shoot(){
        attackTimeCooldown = 0;

        //Object polling
        lazers[NextLazer()].transform.position = firePoint.position;
        lazers[NextLazer()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.z));
        lazers[NextLazer()].SetActive(true);
        }

    private int NextLazer(){
        for (int i = 0; i < lazers.Length; i++){
            if (!lazers[i].activeInHierarchy){
                return i;
            }
       }
       return 0;
    }

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Gun"){
            bulletCount = 3;
        }
    }
}
