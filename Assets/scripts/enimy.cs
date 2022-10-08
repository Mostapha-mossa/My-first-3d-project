using UnityEngine;
using UnityEngine.UI;

public class enimy : MonoBehaviour
{
    public float StartSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float StartHealth = 100;
    private float health;

    public int worth = 50;
    public GameObject deathEffect;
    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;
    public void Start()
    {
        speed = StartSpeed;
        health = StartHealth;
    }
    public void takeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / StartHealth;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    public void Slow(float pct)
    {
        speed = StartSpeed * (1f - pct);
    }
    void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;
        GameObject effect =(GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,5f);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
   
}
