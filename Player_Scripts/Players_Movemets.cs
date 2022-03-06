using System.Collections;
using UnityEngine;

public class Players_Movemets : MonoBehaviour
{
    //[SerializeField] public int speed;
    //public Rigidbody player;
    //public int jumpForce = 20;
    //public int gravitymodifier = 1;
    //public bool touchingGround = true;
    private float horizontalInput;

    //This variable will keep track of the starting positon of the player
    private Vector3 startPoint;
    [SerializeField] public GameObject player;

    //void Awake()
    //{
    //    player = GetComponent<Rigidbody>();
    //}

    //void Update() {
    //    horizontalInput = Input.GetAxis("Horizontal");
    //    player.velocity = new Vector3(horizontalInput * speed, player.velocity.y, player.velocity.z);

    //    //Flip the character
    //    if (horizontalInput > 0.01f)
    //        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    //    else if (horizontalInput < -0.01f)
    //        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -(transform.localScale.z));

    //    if (Input.GetKey(KeyCode.Space) && touchingGround)
    //        Jump();
    //}

    //public void Jump() {
    //    player.velocity = new Vector3(player.velocity.x, speed, player.velocity.z);
    //    touchingGround = false;
    //}

    //private bool IsGrounded() {
    //    return touchingGround;
    //}

    //public bool CanAttack() { 
    //    return horizontalInput == 0 && IsGrounded();
    //}

    ////checks if player is touching the ground
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        touchingGround = true;
    //        gravitymodifier = 1;
    //    }
    //}


    public int speed = 25;
    private Rigidbody rb;
    public float jumpForce = 20f;
    private int gravitymodifier = 5;
    public bool touchingGround = true;
    private bool jumped;
    private bool isGround;
    private float h;
    public static bool IsInputEnabled;
    public GameObject skateBoard;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsInputEnabled = true;
        startPoint = transform.position;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        MovePlayer();
        Playerjump();

        //Reposiiton player if fallen off the platform
        if (transform.position.y <= -350.0f) {
            RespawnAtStart();
            //StartCoroutine(WaitBeforeRespanwn());
        }
    }

    //private IEnumerator WaitBeforeRespanwn() {
    //    yield return new WaitForSeconds(5);

    //}

    private void RespawnAtStart() {
        //Flip the character if it's facing backwards
        if (transform.localScale.z <= 0f) {
            transform.localScale = new Vector3(transform.localScale.x,
                transform.localScale.y, -(transform.localScale.z));
        }
        transform.position = startPoint;
    }

    void MovePlayer()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) && touchingGround)
        {
            //rb.AddForce(Vector2.up * 5 * jumpForce, ForceMode.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce * speed , rb.velocity.z);
            touchingGround = false;
            //Playerjump();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime * speed, transform.position.y, transform.position.z);
            //rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, rb.velocity.z);
        }


        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
            //rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, rb.velocity.z);
        }
    }

    // Tim modify the walf function
    // Update frame every 0.02 s (every fixed time we update)
    void FixedUpdate()
    {
        PlayerWalk();
    }



    void PlayerWalk()
    {
        h = Input.GetAxisRaw("Horizontal"); // input from key left or right
        if (h > 0 && IsInputEnabled)
        {
            rb.velocity = new Vector2(2 * speed, rb.velocity.y);// the charactor moving to right(position speed), but continue hold the ypos
            ChangeDirection(1);
        }
        else if (h < 0 && IsInputEnabled)
        {
            rb.velocity = new Vector2(-2 * speed, rb.velocity.y);
            ChangeDirection(-1);
        }

        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
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

    public void ChangeDirection(int direction)
    {
        //vector 3 is x, y and z
        Vector3 tempScale = transform.localScale;
        tempScale.z = direction;
        transform.localScale = tempScale;
    }

    // function for jump movement after pressing the space key
    void Playerjump()
    {
        if (touchingGround) {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) && touchingGround) {
                jumped = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                touchingGround = false;
            }
        }
    }

    //checks if player is touching the ground
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            touchingGround = true;
            gravitymodifier = 1;
        }
    }
}
