using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //This will determine the speed of the projectile
    [SerializeField] private float speed;
    private float lifeTime; //Representation of how long a lazer/projectile will be active
    private bool hit;
    private float direction;

    private BoxCollider boxCollider;
    private Animator animator;


    // Start is called before the first frame update
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision) {
        hit = true;
        boxCollider.enabled = false;
        animator.SetTrigger("Explode");
    }

    //private void OnCollisionEnter(Collision collision) {
    //    hit = true;
    //    boxCollider.enabled = false;
    //    gameObject.SetActive(false);
    //}

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
