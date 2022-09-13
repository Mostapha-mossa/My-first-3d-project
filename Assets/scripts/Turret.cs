using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header ("Attributes")]
    public float range = 15f;
    public float fireRste = 1f;
    private float fireCountdown = 0f;
    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotat;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortesDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortesDistance <= range)
        {
            target = nearestEnemy.transform;
        }else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        //target look on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotat.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
        partToRotat.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (fireCountdown <= 0f)
        {
            shoot();
            fireCountdown = 1f / fireRste;
        }
        fireCountdown -= Time.deltaTime;
    }
    void shoot()
    {
        GameObject bulletGO=(GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet Bullet = bulletGO.GetComponent<bullet>();
        if (Bullet != null)
        {
            Bullet.seek(target);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
