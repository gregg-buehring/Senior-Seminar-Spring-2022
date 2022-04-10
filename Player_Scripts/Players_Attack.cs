using UnityEngine;

public class Players_Attack : MonoBehaviour
{
    //Variable to keep track of when the next shot can be taken
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] lazers;
    private float attackTimeCooldown = Mathf.Infinity;

    //Added during cycle 3
    public int lives = 3;
    public int attack_damage = 1;
    public bool isDead = false;
    public bool isAttacking = false;
    [SerializeField] GameObject GameOver;
    [SerializeField] AudioSource attack;
    [SerializeField] AudioSource injured;
    [SerializeField] AudioSource death;

    //Grab a reference to the player's movement script
    private Players_Movemets playerMovements;

    //Keep bullet count
    public int bulletCount = 0;

    //private void Start() {
    //    GameOver = GameObject.FindGameObjectWithTag("Game Over");
    //    GameOver.SetActive(false);
    //}

    // Awake is called before the first frame update / when the script is loaded
    private void Awake()
    {
        //Grab references to the components
        playerMovements = GetComponent<Players_Movemets>();
    }

    private void Update()
    {
        //Check if the left mouse button is pressed.
        if (Input.GetMouseButton(0) && attackTimeCooldown > attackCooldown)
            Attack();
        attackTimeCooldown += Time.deltaTime;


        if (isDead) {
            gameOver();
        }
        else {
            if (Input.GetKey(KeyCode.F)) {
                isAttacking = true;
                attack.Play();
            }
            else {
                isAttacking = false;
            }
        }
    }

    void gameOver()
    {
        death.Play();
        GameOver.SetActive(true);
        gameObject.GetComponent<Players_Movemets>().speed = 0;
    }

    private void Attack()
    {
        attackTimeCooldown = 0;

        //Object polling
        lazers[NextLazer()].transform.position = firePoint.position;
        lazers[NextLazer()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.z));
    }

    private int NextLazer() {
        for (int i = 0; i < lazers.Length; i++) {
            if (!lazers[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    void OnCollisionEnter(Collision collision) {
        if ((collision.gameObject.tag == "Enemy") && (!isAttacking)) {
            injured.Play();
            lives -= GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy_Attack_Damage3D>().attack_damage;
            if (lives == 0) {
                isDead = true;
            }
        }
    }
}
