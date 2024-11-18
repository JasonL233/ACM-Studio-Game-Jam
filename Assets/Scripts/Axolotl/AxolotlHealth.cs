using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AxolotlHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    private int maxHealth = 100;
    private int currHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currHealth = maxHealth;
        Debug.Log("Start health: " + currHealth);
    }

    public void takeDamage(int damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            Destroy(gameObject);
            die();
        }

        Debug.Log("Current health: " + currHealth);
    }

    private void die()
    {
        Debug.Log("Axolotl has died! Restarting scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int getHealth()
    {
        return currHealth;
    }
}
