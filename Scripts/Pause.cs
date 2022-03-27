using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    [SerializeField] GameObject resumeText;
    [SerializeField] GameObject quitText;

    // Update is called once per frame
    void Update() {
        if((Input.GetKeyDown(KeyCode.Escape))&&(!isPaused)){
            isPaused = true;
            PauseGame();
        }
    }

    void PauseGame(){
        Time.timeScale = 0;
        resumeText.SetActive(true);
        quitText.SetActive(true);
    }

    public void UnpauseGame(){
        isPaused = false;
        Time.timeScale = 1;
        resumeText.SetActive(false);
        quitText.SetActive(false);
    }
}
