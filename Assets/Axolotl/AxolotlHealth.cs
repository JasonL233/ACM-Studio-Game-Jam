using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxolotlHealth : MonoBehaviour
{
    public int hp;
    public int maxHP = 100;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    public void takeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
