using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    [SerializeField] GameObject[] heart1= new GameObject[4];
    [SerializeField] GameObject[] heart2= new GameObject[4];
    [SerializeField] GameObject player;
        // Start is called before the first frame update
        void Start()
        {
            heart1[0].SetActive(false);
            heart1[1].SetActive(false);
            heart1[2].SetActive(false);
            heart1[3].SetActive(false);
            heart2[0].SetActive(false);
            heart2[1].SetActive(false);
            heart2[2].SetActive(false);
            heart2[3].SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            int lives = player.GetComponent<Player_Health>().lives;

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
