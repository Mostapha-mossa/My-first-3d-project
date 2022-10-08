using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFater sceneFater;
    public string menu = "MainMenu";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;

        }else
        {
            Time.timeScale = 1;
        }

    }
    public void Retry()
    {
        Toggle();
        sceneFater.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Toggle();
        sceneFater.FadeTo(menu);
    }
}
