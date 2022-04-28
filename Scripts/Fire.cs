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
    public GameObject cube;
  
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
         transform.position =  Vector3.MoveTowards(transform.position, cube.transform.position, 2f);
    }
}
