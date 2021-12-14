using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bulletEnCollision : MonoBehaviour
{
    public GameObject hitEffect;
    private Character character;
    private int damage;
    void SetDamage(int damage)
    {
        Debug.Log("SetDamage");
        this.damage = damage;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        if (collision.gameObject.name == "Character")
        {
            collision.gameObject.SendMessage("TakeDamage", collision.otherCollider.gameObject.transform.GetComponent<Bullet>().damage);
        }

        Destroy(gameObject);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

    }
}
