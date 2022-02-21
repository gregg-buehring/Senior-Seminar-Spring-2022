using UnityEngine;

public class Players_Movemets : MonoBehaviour
{
    [SerializeField] public int speed;
    public Rigidbody player;
    public int jumpForce = 20;
    public int gravitymodifier = 1;
    public bool touchingGround = true;
    private float horizontalInput;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        player.velocity = new Vector3(horizontalInput * speed, player.velocity.y, player.velocity.z);

        //Flip the character
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -(transform.localScale.z));

        if (Input.GetKey(KeyCode.Space) && touchingGround)
            Jump();
    }

    public void Jump() {
        player.velocity = new Vector3(player.velocity.x, speed, player.velocity.z);
        touchingGround = false;
    }

    private bool IsGrounded() {
        return touchingGround;
    }

    public bool CanAttack() { 
        return horizontalInput == 0 && IsGrounded();
    }

    //checks if player is touching the ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            touchingGround = true;
            gravitymodifier = 1;
        }
    }

}
