using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class endGame : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text winningText;
    public TextMesh debug;
    public GameObject gameOverScreen;
    public GameObject Ui;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GameObject parentOfsoldier = GameObject.Find("wormsList");
        int nbChildWorms = parentOfsoldier.transform.childCount;
        List<GameObject> playerList = new List<GameObject>();
        List<GameObject> aiList = new List<GameObject>();

        for (int i = 0; i < nbChildWorms; i++)
        {
            GameObject child = parentOfsoldier.transform.GetChild(i).gameObject;

            if (child.CompareTag("Player"))
            {
                playerList.Add(child);
            }
            else
            {
                aiList.Add(child);
            }
        }
        if(aiList.Count == 0)
        {
            //Player win
            Time.timeScale = 0;
            winningText.text = "Player win";
            gameOverScreen.SetActive(true);
            Ui.SetActive(false);

        }

        if(playerList.Count == 0)
        {
            //Ai win
            Time.timeScale = 0;
            winningText.text = "Ai win";
            gameOverScreen.SetActive(true);
            Ui.SetActive(false);
        }
    }
}
