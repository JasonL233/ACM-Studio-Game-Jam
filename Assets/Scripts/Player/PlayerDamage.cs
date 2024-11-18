using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int dmg;
    public AxolotlHealth axolotlHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Axolotl>().tag == "Axolotl")
        {
            // axolotlHealth.takeDamage(dmg);
        }
    }
}
