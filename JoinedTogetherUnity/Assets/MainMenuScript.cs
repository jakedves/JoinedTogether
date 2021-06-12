using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    // Takes the user to the next scene when "PLAY" is selected
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quits the game when the "QUIT" button is selected
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
