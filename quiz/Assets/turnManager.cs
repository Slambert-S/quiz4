using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> playerList;
    public List<GameObject> aiList;
    public Camera camera;
    public int side;
    public int playerTurnOrder = 0;
    public int aiTurnOrder = 0;
    public bool aiIsRunning = false;
    
    void Start()
    {

        GameObject parentOfsoldier = GameObject.Find("wormsList");
        int nbChildWorms = parentOfsoldier.transform.childCount;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(side == 0)
        {
            //players turn
            if(playerTurnOrder >= playerList.Count)
            {
                playerTurnOrder = 0;
            }

            playerList[playerTurnOrder].GetComponent<playerController>().enabled = true;
            camera.GetComponent<folowPLayer>().player = playerList[playerTurnOrder].transform;


        }
        else if(side == 2)
        {
            //Ai turn;
            if(aiTurnOrder >= aiList.Count)
            {
                aiTurnOrder = 0;
            }
            if(aiIsRunning == false)
            {
                Debug.Log("in ai turn");
                aiList[aiTurnOrder].GetComponent<enemyTimer>().ResetTimer();
                aiList[aiTurnOrder].GetComponent<enemyTimer>().startTimer();
                aiList[aiTurnOrder].GetComponent<enemyVariable>().canActe = true;

                camera.GetComponent<folowPLayer>().player = aiList[aiTurnOrder].transform;
                aiIsRunning = true;

            }


        }
        else if (side == 1 || side == 3) { 
        
        
        }

    }

    public void playerEndTurn()
    {
        playerTurnOrder++;
        side = 1;

    }

    public void aiEndTurn()
    {
        aiTurnOrder++;
        side = 3;
        aiIsRunning = false;
    }
    public void bullethit()
    { 
        if( side == 1)
        {
            side = 2;
        }
        else if( side == 3)
        {
            aiList[aiTurnOrder -1].GetComponent<enemyVariable>().tookhisShot = false;
            side = 0;
            Debug.Log("in side == 3");
            aiIsRunning = false;
        }

    }
}
