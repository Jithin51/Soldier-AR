using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;

    public HealthBar healthBar;

    private void Start()
    {
        healthBar.setMaxHealth(health);
        healthBar.setHealth(health);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.setHealth(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
