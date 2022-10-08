using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundText;
    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(0.7f);
        while (round < PlayerStats.Rounds)
        {
            round++;
            roundText.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
