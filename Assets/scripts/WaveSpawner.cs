using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBrtweenWaves = 20f;
    private float countdown = 2f;
    public Text WavecountDownText;
    public GameManager gameManager;
    private int waveNumber = 0;
    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBrtweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        WavecountDownText.text = string.Format("{0:00.00}",countdown);
    }
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveNumber];
        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber++;
     
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
