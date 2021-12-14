using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public float damage = 20;
    public GameObject pistolAmmoPrefab;
    public GameObject shotgunAmmoPrefab;
    public GameObject rifleAmmoPrefab;
    public GameObject firstAidPrefab;
    public Transform enemyPos;
    private Character character;
    public int points;

    void Start()
    {
        health = maxHealth;
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
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
        Destroy(gameObject, 0.01f);
        character.SendMessage("AddPoints", points);
        var rand = Random.Range(1, 20);
        if(rand<=3)
        {
            GameObject ammo = Instantiate(pistolAmmoPrefab, enemyPos.position, enemyPos.rotation);
            Rigidbody2D rb = ammo.GetComponent<Rigidbody2D>();
            Debug.Log("pistol");
        }
        else if(rand >3 && rand<=5)
        {
            GameObject firstAid = Instantiate(firstAidPrefab, enemyPos.position, enemyPos.rotation);
            Rigidbody2D rb = firstAid.GetComponent<Rigidbody2D>();
        }
        else if (rand > 5 && rand <= 8)
        {
            GameObject firstAid = Instantiate(shotgunAmmoPrefab, enemyPos.position, enemyPos.rotation);
            Rigidbody2D rb = firstAid.GetComponent<Rigidbody2D>();
            Debug.Log("shotgun");
        }
        else if (rand > 8 && rand <= 11)
        {
            GameObject firstAid = Instantiate(rifleAmmoPrefab, enemyPos.position, enemyPos.rotation);
            Rigidbody2D rb = firstAid.GetComponent<Rigidbody2D>();
            Debug.Log("rifle");
        }

    }
}
