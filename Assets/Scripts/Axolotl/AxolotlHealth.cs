using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AxolotlHealth : MonoBehaviour
{
    public HealthManager healthManager;

    private Rigidbody2D rb;
    public int maxHealth = 100;
    public int currHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        currHealth -= damage;

        if (healthManager != null)
        {
            healthManager.lossHealth(damage);
            Debug.Log("function called!");
        }

        if (currHealth <= 0)
        {
            Destroy(gameObject);
            die();
        }
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
