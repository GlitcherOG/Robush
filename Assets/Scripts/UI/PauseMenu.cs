using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked; //Locks the cursor
            Cursor.visible = false; //Hides the cursor
            Time.timeScale = 1; // sets the time of the world to one
            pauseMenu.SetActive(false); //Hides the pause menu
            isPaused = false; //Changes the bool for being paused
        }
        else
        {
            Cursor.lockState = CursorLockMode.None; //unlocks the cursor
            Cursor.visible = true; //shows the cursor
            Time.timeScale = 0; //Sets the time scale to 0
            pauseMenu.SetActive(true); //shows the menu
            isPaused = true;//Changes the bool for being paused
        }
    }
}
