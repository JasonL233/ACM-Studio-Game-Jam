using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actors
{
    public int damage = 3;
    public override int maxHP => 0;
    public Transform player;

    public virtual void Start()
    {
        base.Start();
        GetTarget();
    }
    public virtual void MoveTowardPlayer()
    {
        // Move toward the player's position
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
    public virtual void GetTarget()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Axolotl");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
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
