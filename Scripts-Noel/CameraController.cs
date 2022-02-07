using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Moveing to a new room
    //[SerializeField] private float speed; //Specifies how fast the camera is moving.

    //private Vector3 velocity = Vector3.zero; // Will work as rate of change of the camera position

    //Following the player
    private float posX; // Current position
    [SerializeField] private Transform player; //Object we want to follow
    [SerializeField] private float aheadDistance; //Will tell us how far ahead the camera can see
    [SerializeField] private float cameraSpeed;
    private float lookAhead;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moveing to a new room
        //The Unity documentation says this is used to gradually changed a vector towards a desired goal over time.
        //It uses some spring-damper like function which will never overshoot.
        //Most common use is for smoothing a follow camera.
        //.SmoothDamp(currentCameraPosition, destinationPosition, velocityVector, speedOfMovement) -> Time.deltaTime makes it frame independent
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(posX, transform.position.y, transform.position.z), ref velocity, speed * Time.deltaTime);

        //Following the player
        //Camera will follow player in the x and y axis
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);
        //Set lookAhead gradually from 0 to whatever aherad distance is multiplied by the x position of the player
        //We can use Lerp for this. Lerp accepts 3 arguments (start, end, how fast) 
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void CameraMove(Transform _newRoom) { 
        posX = _newRoom.position.x;
    }
}
