using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class completeLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level 2";
    public int levelToUnlock = 2;

    public SceneFater fater;



    public void Continue()
    {
        Debug.Log("level Won!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        fater.FadeTo(nextLevel);
    }
    public void Menu()
    {
        fater.FadeTo(menuSceneName);

    }
}
