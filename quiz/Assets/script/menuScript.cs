using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }
    public void goToMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void quitGame()
    {
        Application.Quit();
    }
}
