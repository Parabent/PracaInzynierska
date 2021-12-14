using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisonWithPlayer : MonoBehaviour
{
    private Character character;

    private void OnCollisionStay2D(Collision2D collision)
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        try
        {
            if (collision.gameObject.tag == "Player")
            {
                character.TakeDamage(2f);
            }
        }
        catch (Exception) { }
    }
}
