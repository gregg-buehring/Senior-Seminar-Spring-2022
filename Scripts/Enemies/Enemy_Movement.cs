using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    public int speed = 15;
    Rigidbody2D rb;
    [SerializeField] Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x < transform.position.x){
           this.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
         }
         else{
            this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
         }
    }
}
