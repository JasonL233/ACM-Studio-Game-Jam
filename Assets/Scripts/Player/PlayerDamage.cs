using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int dmg;
    public AIChase meleeEnemy;
    public AIChaseAndRangedAttack rangedEnemy;
    public int enemiesKilled = 0;
    public bool isCollide;

    void Start()
    {
        isCollide = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.takeDamage(dmg);
            enemiesKilled++;

            if (enemiesKilled > 20)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("Game over! You win! :D");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCollide = true; // Set to true when a collision starts
    }

    private void OnCollisionExit(Collision collision)
    {
        isCollide = false; // Set to false when collision ends
    }
    public bool isColliding()
    {
        return isCollide;
    }
}
