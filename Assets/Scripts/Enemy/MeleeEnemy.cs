using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public Transform player;
    public float speed;
    public int damage = 3;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetTarget(); // Attempt to assign the player at the start
    }

    void Update()
    {
        if (!player)
        {
            GetTarget();
            if (!player) return; // Exit if player is still not found
        }

        // Calculate direction toward the player
        Vector2 direction = player.position - transform.position;
        direction.Normalize();

        // Rotate to face the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Move toward the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Axolotl"))
        {
            AxolotlHealth axolotlHealth = collision.gameObject.GetComponent<AxolotlHealth>();
            if (axolotlHealth != null)
            {
                axolotlHealth.takeDamage(damage);
            }
        }
    }
}
