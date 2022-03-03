using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCount : MonoBehaviour
{
    [SerializeField] GameObject[] bullets= new GameObject[3];
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        bullets[0].SetActive(false);
        bullets[1].SetActive(false);
        bullets[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int num = player.GetComponent<Player_Attack>().bulletCount;
        if(num == 0){
            bullets[0].SetActive(false);
            bullets[1].SetActive(false);
            bullets[2].SetActive(false);
        }
        else if(num == 1){
            bullets[0].SetActive(true);
            bullets[1].SetActive(false);
            bullets[2].SetActive(false);
        }
        else if(num == 2){
            bullets[0].SetActive(true);
            bullets[1].SetActive(true);
            bullets[2].SetActive(false);
        }
        else{
            bullets[0].SetActive(true);
            bullets[1].SetActive(true);
            bullets[2].SetActive(true);
        }
    }
}
