using UnityEngine;
using UnityEngine.UI;

public class LviesUI : MonoBehaviour
{
    public Text livesText;
    
    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerStats.lives + "Lives";
    }
}
