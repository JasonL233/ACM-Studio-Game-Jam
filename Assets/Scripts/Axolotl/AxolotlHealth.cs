using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AxolotlHealth : Actors
{
    public HealthManager healthManager;

    public void takeDamage(int dmg)
    {
        base.takeDamage(dmg);

        if (healthManager != null)
        {
            healthManager.lossHealth(dmg);
        }
    }

    public void Die()
    {
        base.Die();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game over! You lose :(");
    }
}
