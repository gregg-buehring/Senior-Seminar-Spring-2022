using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour

{

    public float moveSpeed = 1f;
	private Rigidbody2D myBody;
    private Vector3 offset;
    
    Rigidbody2D rb;
    
    Vector2 moveDirection; 
    public GameObject player;
    void Awake(){
        player = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
         transform.position =  Vector3.MoveTowards(transform.position, player.transform.position, 2f);
    }
}
