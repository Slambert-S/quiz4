using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    bool pausedGame = false;
    public GameObject gameUi;
    public GameObject pauseMenuUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("p"))
        {
            if(pausedGame == false)
            {
                Time.timeScale = 0;
                pauseMenuUI.SetActive(true);
                gameUi.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenuUI.SetActive(true);
                gameUi.SetActive(true);
            }
        }


    }
}
