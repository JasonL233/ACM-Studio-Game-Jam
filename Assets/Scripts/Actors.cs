using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actors : MonoBehaviour
{
    private Rigidbody2D rb;
    public int hp;
    public virtual int maxHP => 100;
    public float speed;
    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = maxHP;
    }

    public virtual void takeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    public virtual int getHealth()
    {
        return hp;
    }
}
