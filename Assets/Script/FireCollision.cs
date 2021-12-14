using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FireCollision : MonoBehaviour
{
    private Character character;
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    //    if (collision.gameObject.name == "Character")
    //    {
    //        collision.gameObject.SendMessage("TakeDamage", 0.1f);
    //    }
    //}
    void OnTriggerStay2D(Collider2D collision)
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        try
        {
            if (collision.attachedRigidbody.name == "Character")
            {
                character.SendMessage("TakeDamage", 0.5f);
            }
        }
        catch (Exception) { }

  
         
        
    }
}
