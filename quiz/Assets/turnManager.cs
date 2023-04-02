using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> playerList;
    public List<int> removeList;
    public List<GameObject> aiList;
    public Camera camera;
    public int side;
    public int playerTurnOrder = 0;
    public int aiTurnOrder = 0;
    public bool aiIsRunning = false;
    public bool playerIsRunning = false;

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
            if(playerList[playerTurnOrder] != null)
            {
                if(playerIsRunning == false)
                {

                    playerList[playerTurnOrder].GetComponent<playerController>().enabled = true;
                    playerList[playerTurnOrder].GetComponent<playerTimer>().ResetTimer();
                    playerList[playerTurnOrder].GetComponent<playerTimer>().startTimer();
                    playerList[playerTurnOrder].GetComponent<previewTrajectory>().enabled = true;
                    camera.GetComponent<folowPLayer>().player = playerList[playerTurnOrder].transform;
                    playerIsRunning = true;
                }

            }
            else
            {
                playerTurnOrder++;
            }


        }
        else if(side == 2)
        {
            //Ai turn;
            if(aiTurnOrder >= aiList.Count)
            {
                aiTurnOrder = 0;
            }

            if (aiList[aiTurnOrder] != null)
            {
                if (aiIsRunning == false)
                {
                    Debug.Log("in ai turn");

                    aiList[aiTurnOrder].GetComponent<enemyTimer>().ResetTimer();
                    aiList[aiTurnOrder].GetComponent<enemyTimer>().startTimer();
                    aiList[aiTurnOrder].GetComponent<enemyVariable>().canActe = true;

                    camera.GetComponent<folowPLayer>().player = aiList[aiTurnOrder].transform;
                    aiIsRunning = true;

                }
            }
            else {
                aiTurnOrder++;
            };
            


        }
        else if (side == 1 || side == 3) { 
        
        
        }

    }

    public void playerEndTurn()
    {
        playerTurnOrder++;
        playerIsRunning = false;
        side = 1;

    }

    public void aiEndTurn()
    {
        aiList[aiTurnOrder].GetComponent<enemyVariable>().tookhisShot = false;
        aiTurnOrder++;
        side = 3;
        aiIsRunning = false;
    }
    public void bullethit()
    {
        
        
        if ( side == 1)
        {
            side = 2;
        }
        else if( side == 3)
        {
           // aiList[aiTurnOrder-1].GetComponent<enemyVariable>().tookhisShot = false;
            side = 0;
            Debug.Log("in side == 3");
            aiIsRunning = false;
        }

    }
}
