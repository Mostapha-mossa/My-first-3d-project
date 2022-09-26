using UnityEngine;

public class enimy : MonoBehaviour
{
    public float StartSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int worth = 50;
    public GameObject deathEffect;
    public void Start()
    {
        speed = StartSpeed;
    }
    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
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
        PlayerStats.Money += worth;
        GameObject effect =(GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,5f);
        Destroy(gameObject);
    }
   
}
