using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public SceneFater sceneFater;
    public string menu = "MainMenu";

    public void Retry()
    {
        sceneFater.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sceneFater.FadeTo(menu);
    }
}
