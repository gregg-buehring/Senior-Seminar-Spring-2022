using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movements : MonoBehaviour
{
    //Following the player
    [SerializeField] private Transform player; //Object we want to follow
    [SerializeField] private float aheadDistance; //Will tell us how far ahead the camera can see
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    // Update is called once per frame
    void Update()
    {
        //Following the player
        //Camera will follow player in the x and y axis
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);
        //Set lookAhead gradually from 0 to whatever aherad distance is multiplied by the x position of the player
        //We can use Lerp for this. Lerp accepts 3 arguments (start, end, how fast) 
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.z), Time.deltaTime * cameraSpeed);
    }
}
