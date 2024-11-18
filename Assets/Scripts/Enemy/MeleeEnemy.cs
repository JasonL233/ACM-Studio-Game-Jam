using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : Enemy
{
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
        MoveTowardPlayer();
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
