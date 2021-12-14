using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float maxHealth = 200;
    public float health;
    public float damage = 50;
    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        Destroy(gameObject, 0.2f);
        Debug.Log(gameObject);
    }
}
