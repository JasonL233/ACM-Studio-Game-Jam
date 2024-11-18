using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseAndRangedAttack : Enemy
{
    public GameObject bulletPrefab;
    public float shootingRange; // Range within which the enemy shoots
    public Transform FiringPoint;
    public float fireRate;
    private float distanceToPlayer; // Distance to the player
    private float timeToFire;

    void Update()
    {
        if (!player)
        {
            GetTarget();
            if (!player) return; // Exit if player is still not found
        }

        // Calculate distance to the player
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Calculate direction and rotate to face the player
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        // Behavior based on distance to player
        if (distanceToPlayer > shootingRange)
        {
            MoveTowardPlayer(); // Chase the player if outside shooting range
        }
        else if (distanceToPlayer <= shootingRange)
        {
            ShootAtPlayer(); // Shoot if within range and cooldown allows
        }
    }

    void ShootAtPlayer()
    {
        if (timeToFire <= 0f)
        {
            Instantiate(bulletPrefab, FiringPoint.position, FiringPoint.rotation);
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }
}
