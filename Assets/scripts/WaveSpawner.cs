using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefeb;
    public Transform spawnPoint;
    public float timeBrtweenWaves = 20f;
    private float countdown = 2f;
    public Text WavecountDownText;
    private int waveNumber = 0;
    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBrtweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        WavecountDownText.text = string.Format("{0:00.00}",countdown);
    }
    IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefeb, spawnPoint.position, spawnPoint.rotation);
    }
}
