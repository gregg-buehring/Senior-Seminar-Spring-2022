using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource beginningBackground;
    [SerializeField] AudioSource backgroundLoop;
    public bool begin = true;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        if((!beginningBackground.isPlaying)&&(begin)){
            backgroundLoop.Play();
            begin = false;
        }
    }
}
