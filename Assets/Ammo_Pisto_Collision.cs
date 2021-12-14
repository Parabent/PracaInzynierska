using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ammo_Pisto_Collision : MonoBehaviour
{
    private Character character;
    public Ammo _ammo;
    void OnTriggerEnter2D(Collider2D collision)
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        //_ammo = GameObject.FindGameObjectWithTag("AmmoText").GetComponent<Ammo>();
        try
        {
            if (collision.attachedRigidbody.name == "Character")
            {
                Stats.pistolAmmo += 20;
                character.SendMessage("PickAmmo", 1);
                
                Destroy(gameObject);
            }
        }
        catch (Exception) { }

    }
}
