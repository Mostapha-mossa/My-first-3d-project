using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (gameEnded == true)
        {
            return;
        }
        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
        
    }
    void EndGame()
    {
        gameEnded = true;
        Debug.Log("The Game Over!");
    }
}
