using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth;
    private int currentHealth;

    public FloatingHealthBar floatingHealthBar;

    private void Start()
    {
        currentHealth = maxHealth;

        // Ensure that you have assigned the FloatingHealthBar component to the enemy GameObject
        floatingHealthBar.updateHealthBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        floatingHealthBar.updateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
