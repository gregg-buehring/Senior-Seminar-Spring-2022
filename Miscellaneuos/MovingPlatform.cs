using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    [SerializeField] private Transform[] bounderies;
    [SerializeField] float speed;
    [SerializeField] private int startingPoint;
    private int target;

    void Start() {
        transform.position = bounderies[startingPoint].position;
    }

    // Update is called once per frame
    void Update() {

        //check to change the index of the boundery to which to move to
        if (Vector2.Distance(transform.position, bounderies[target].position) < 0.01f) {
            target++;

            if (target == bounderies.Length) {
                target = 0;
            }
        }  

        //MoveToward accepts (current posiiton of the object, position to which to move, speed)
        transform.position = Vector3.MoveTowards(transform.position, bounderies[target].position, speed * Time.deltaTime);
        
    }

    //Make player a child of the platform so that it sticks with the platform
    private void OnCollisionEnter(Collision collision) {
        collision.transform.SetParent(transform);
    }

    //Makes the player not have a parent so that the player can move on its own.
    private void OnCollisionExit(Collision collision) {
        collision.transform.SetParent(null);
    }

    //Anything that happends in this function, happens after the update function
    //That means that we are going to use data received from the update function
    //private void FixedUpdate() {
        
    //}
}
