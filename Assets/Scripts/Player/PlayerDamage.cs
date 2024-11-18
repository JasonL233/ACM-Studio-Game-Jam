using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int dmg;
    public AIChase meleeEnemy;
    public AIChaseAndRangedAttack rangedEnemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            meleeEnemy = collision.gameObject.GetComponent<AIChase>();
            rangedEnemy = collision.gameObject.GetComponent<AIChaseAndRangedAttack>();
            if (meleeEnemy)
            {
                meleeEnemy.takeDamage();
            }
            else
            {
                rangedEnemy.takeDamage();
            }
        }
    }
}
