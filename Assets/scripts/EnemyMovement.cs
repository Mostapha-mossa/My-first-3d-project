using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enimy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    private enimy enemy;

    private void Start()
    {
        enemy = GetComponent<enimy>();
        target = waypoints.points[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.StartSpeed;
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
    }
    void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}
