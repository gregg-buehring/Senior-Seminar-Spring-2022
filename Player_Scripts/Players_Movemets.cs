using System.Collections;
using UnityEngine;

public class Players_Movemets : MonoBehaviour {

    //This variable will keep track of the starting positon of the player
    private Vector3 startPoint;
    [SerializeField] public GameObject player;
    public int speed = 25;
    public float zScale;
    private Rigidbody rb;
    public float jumpForce = 15f;
    private int gravitymodifier = 5;
    public bool touchingGround = true;
    private bool jumped;
    private bool isGround;
    private float h;
    public static bool IsInputEnabled;
    public GameObject skateBoard;
    private Animator anim;

    private Player_Health playerHealth;


    void Start() {
        rb = GetComponent<Rigidbody>();
        playerHealth = GetComponent<Player_Health>();
        anim = GetComponent<Animator>();
        IsInputEnabled = true;
        startPoint = transform.position;
        zScale = transform.localScale.z;
    }

    void Update() {
        h = Input.GetAxis("Horizontal"); // input from key left or right
        rb.velocity = new Vector3(h * 2 * speed, rb.velocity.y, rb.velocity.z);

        if (h > 0.01f)
            transform.localScale = Vector3.one;
        else if (h < -0.01f)
            transform.localScale = new Vector3(1, 1, -1);

        if (Input.GetKey(KeyCode.Space) && touchingGround)
            Playerjump();

        anim.SetBool("Walk", h != 0);
        anim.SetBool("Grounded", touchingGround);
        anim.SetBool("Falling", transform.position.y < 2.0f);


        //Reposiiton player if fallen off the platform
        if (transform.position.y <= -350.0f) {
            RespawnAtStart();
        }
    }

    private void RespawnAtStart() {
        //Flip the character if it's facing backwards
        if (transform.localScale.z <= 0f) {
            transform.localScale = new Vector3(transform.localScale.x,
                transform.localScale.y, -(transform.localScale.z));
        }
        transform.position = startPoint;
    }

    //void MovePlayer() {

    //    if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && touchingGround) {
    //        Playerjump();
    //    }

    //    else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
    //        //transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, 
    //        //    transform.position.y, transform.position.z);
    //        PlayerWalk();
    //    }
    //}

    // Tim modify the walk function
    // Update frame every 0.02 s (every fixed time we update)
    //void FixedUpdate() {
    //    PlayerWalk();
    //}



    //void PlayerWalk() {

    //    if (h > 0 && IsInputEnabled) {
    //        rb.velocity = new Vector2(2 * speed, rb.velocity.y);// the charactor moving to right(position speed), but continue hold the ypos
    //        ChangeDirection(zScale);
    //    } else if (h < 0 && IsInputEnabled) {
    //        rb.velocity = new Vector2(-2 * speed, rb.velocity.y);
    //        ChangeDirection(-zScale);
    //    } else {
    //        rb.velocity = new Vector2(0f, rb.velocity.y);
    //    }
        

    //    anim.SetInteger("Speed", Mathf.Abs((int)rb.velocity.x));
    //}


    // method to disable the input arrow keys when the player on the skateboard
    public void BreakInput()
    {
        IsInputEnabled = true;
    }
    // fucntion to make the player follow the skateboard
    public void FollowSkate()
    {
        transform.position = Vector3.MoveTowards(transform.position, skateBoard.transform.position, 350f);
    }

    public void ChangeDirection(float direction)
    {
        //vector 3 is x, y and z
        Vector3 tempScale = transform.localScale;
        tempScale.z = direction;
        transform.localScale = tempScale;
    }

    // function for jump movement after pressing the space key
    void Playerjump() {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce * speed , rb.velocity.z);
        anim.SetTrigger("Jump");
        touchingGround = false;
    }

    //checks if player is touching the ground
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            touchingGround = true;
            gravitymodifier = 1;
        }

        if (collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "Enemy") {
            playerHealth.lives -= 1; 
        }
    }
}
