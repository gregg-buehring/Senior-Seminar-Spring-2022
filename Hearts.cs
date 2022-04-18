using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public GameObject[] heart1= new GameObject[4];
        public GameObject[] heart2= new GameObject[4];
        [SerializeField] GameObject Heart1_0;
        [SerializeField] GameObject Heart1_1;
        [SerializeField] GameObject Heart1_2;
        [SerializeField] GameObject Heart1_3;
        [SerializeField] GameObject Heart2_0;
        [SerializeField] GameObject Heart2_1;
        [SerializeField] GameObject Heart2_2;
        [SerializeField] GameObject Heart2_3;

        [SerializeField] GameObject player;
        // Start is called before the first frame update
        void Start()
        {
            Heart1_0 = GameObject.Find("Heart1 0");
            heart1[0] = Heart1_0;
            Heart1_1 = GameObject.Find("Heart1 1");
            heart1[1] = Heart1_1;
            Heart1_2 = GameObject.Find("Heart1 2");
            heart1[2] = Heart1_2;
            Heart1_3 = GameObject.Find("Heart1 3");
            heart1[3] = Heart1_3;
            Heart2_0 = GameObject.Find("Heart2 0");
            heart2[0] = Heart2_0;
            Heart2_1 = GameObject.Find("Heart2 1");
            heart2[1] = Heart2_1;
            Heart2_2 = GameObject.Find("Heart2 2");
            heart2[2] = Heart2_2;
            Heart2_3 = GameObject.Find("Heart2 3");
            heart2[3] = Heart2_3;

            heart1[0].SetActive(false);
            heart1[1].SetActive(false);
            heart1[2].SetActive(false);
            heart2[1].SetActive(false);
            heart2[2].SetActive(false);
            heart2[3].SetActive(false);

            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            int lives = player.GetComponent<Player_Attack_Damage3D>().lives;

            if(lives==0){
                heart1[0].SetActive(true);
                heart1[1].SetActive(false);
            }
            if(lives==1){
                heart1[1].SetActive(true);
                heart1[2].SetActive(false);
            }
            if(lives==2){
                heart1[1].SetActive(false);
                heart1[2].SetActive(true);
                heart1[3].SetActive(false);
            }
            if(lives==3){
                heart1[2].SetActive(false);
                heart1[3].SetActive(true);
                heart2[0].SetActive(true);
                heart2[1].SetActive(false);
            }
            if(lives==4){
                heart2[0].SetActive(false);
                heart2[1].SetActive(true);
                heart2[2].SetActive(false);
            }
            if(lives==5){
                heart2[1].SetActive(false);
                heart2[2].SetActive(true);
                heart2[3].SetActive(false);
            }
            if(lives==6){
                heart2[3].SetActive(true);
                heart2[2].SetActive(false);
            }
        }
}
