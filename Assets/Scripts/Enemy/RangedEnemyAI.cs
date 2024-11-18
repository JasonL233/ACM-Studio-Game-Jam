using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseAndRangedAttack : MonoBehaviour
{
    public Transform player; // Reference to the player
    public GameObject bulletPrefab;
    public float speed; // Speed of movement
    public float shootingRange; // Range within which the enemy shoots
    public Transform FiringPoint;
    public float fireRate;


    private Rigidbody2D rb;
    private float distanceToPlayer; // Distance to the player
    private float timeToFire;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Automatically find the player if not assigned in Inspector
        GetTarget();
    }

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

    void MoveTowardPlayer()
    {
        // Move toward the player's position
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
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
        // Debug.Log("Shooting at player!");
    }

    private void GetTarget()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Axolotl");
        if (playerObject != null)
        {
            player = playerObject.transform;
            // Debug.Log("Player assigned: " + player.name);
        }
        else
        {
            // Debug.LogWarning("Player not found!");
        }
    }

    public void takeDamage()
    {
        Destroy(gameObject);
    }

}
