using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Variable to keep track of when the next shot can be taken
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] lazers;
    private float attackTimeCooldown = Mathf.Infinity;
    private Animator animator;

    //Grab a reference to the player's movement script
    private PlayerMovements playerMovements;

    // Awake is called before the first frame update / when the script is loaded
    private void Awake()
    {
        //Grab references to the components
        playerMovements = GetComponent<PlayerMovements>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Check if the left mouse button is pressed.
        if (Input.GetMouseButton(0) && attackTimeCooldown > attackCooldown)
            Attack();
        attackTimeCooldown += Time.deltaTime;
    }

    private void Attack() {
        animator.SetTrigger("attack");
        attackTimeCooldown = 0;

        //Object pooling
        lazers[NextLazer()].transform.position = firePoint.position;
        lazers[NextLazer()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int NextLazer() {
        for (int i = 0; i < lazers.Length; i++) { 
            if(!lazers[i].activeInHierarchy) 
                return i;
        }
        return 0;
    }
}
