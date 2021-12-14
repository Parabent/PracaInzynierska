using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bulletCollision : MonoBehaviour
{
    public GameObject hitEffect;
    private Character character;
    private Enemy enemy;
    private int damage;
    //public float playerDamage;
    //public float enemyDamage;
    void SetDamage(int damage)
    {
        this.damage = damage;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        if (collision.gameObject.name.Contains("Enemy") || collision.gameObject.name.Contains("Boss") || collision.gameObject.tag =="Enemy")
        {
            Enemy other = collision.gameObject.GetComponent<Enemy>();
            if (other)
            {
                other.gameObject.SendMessage("TakeDamage", character.damage);
            }
        }
        if (collision.gameObject.name == "Character")
        {
            //if(collision.otherCollider.GetComponent(Enemy))
            //if(TryGetComponent())
            Debug.Log(collision.otherCollider.gameObject.transform.GetComponent<Bullet>().damage);
            collision.gameObject.SendMessage("TakeDamage", collision.otherCollider.gameObject.transform.GetComponent<Bullet>().damage);
        }
        //if(collision.gameObject.tag =="Door")
        //{
        //    Debug.Log("elo");
        //    Destroy(collision.gameObject);
        //    GameObject effect1 = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //    Destroy(effect1, 2f);
        //}

        Destroy(gameObject);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

    }
}
