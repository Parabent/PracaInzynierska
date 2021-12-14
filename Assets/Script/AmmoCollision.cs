using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollision : MonoBehaviour
{

    private Character character;
    void OnTriggerEnter2D(Collider2D collision)
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        try
        {
            if (collision.attachedRigidbody.name == "Character")
            {
                character.SendMessage("PickAmmo", 20);
                Destroy(gameObject);
            }
        }
        catch (Exception) { }

    }
}
