using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //[SerializeField] makes the field editable from Unity Editor
    [SerializeField] private float speed;
    private Rigidbody2D player;
    private Animator animator;
    private bool grounded = true;
    private float horizontalInput;

    //This is called when the game begins / when the script is loaded
    private void Awake() {
        //Grab reference for rigid body of the player
        player = GetComponent<Rigidbody2D>();

        //Grab reference for animator of the player
        animator = GetComponent<Animator>();
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal"); // Keeps track of the x-axis position on the player
        player.velocity = new Vector2(horizontalInput * speed, player.velocity.y);

        //Flip the character when moving backwards or frontwards
        if (horizontalInput > 0.01f)
            transform.localScale = Vector2.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector2(-1, 1);

        //This code checks if the player in on the ground and space is pressed
        if (Input.GetKey(KeyCode.Space) && grounded) {
            Jump();
        }

        //Set animator parameters
        animator.SetBool("walk", horizontalInput != 0);
        animator.SetBool("grounded", grounded);
    }

    private void Jump() {
        player.velocity = new Vector2(player.velocity.x, speed);
        animator.SetTrigger("jump");
        grounded = false;
    }

    //Use this method to detect collisions (any) 
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }

    private bool IsGrounded() { 
        return grounded;
    }

    //Player can attack if and only if it is not moving in the x or -x direction.
    //and it is on the ground
    public bool CanAttack() {
        return horizontalInput == 0 && IsGrounded();
    }
}
