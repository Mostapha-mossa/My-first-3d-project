using UnityEngine;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour
{
    public SceneFater fater;

    public Button[] levelButtons;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;

            }
        }
    }
    public void Select(string LevelName)
    {
        fater.FadeTo(LevelName);
    }

}
