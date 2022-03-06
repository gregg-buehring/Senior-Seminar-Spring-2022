using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_Movements : MonoBehaviour
{
    public int speed = 15;
    public Rigidbody rb;
    [SerializeField] Transform player;
    public int lastX = 0;
    public bool touchingGround = true;
    public int jumpForce = 20;


    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        if (player.position.x < transform.position.x) {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        }
        else {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            touchingGround = true;
        }
    }

    void OnTriggerEnter(Collider collision) {
        if ((collision.gameObject.tag == "Ground") && (touchingGround)) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            touchingGround = false;
        }
    }
}
