using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused==false)
            {
                pauseMenu.SetActive(true);
                isPaused = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                pauseMenu.SetActive(false);
                isPaused = false;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
