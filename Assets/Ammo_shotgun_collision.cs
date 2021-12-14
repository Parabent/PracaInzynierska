using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_shotgun_collision : MonoBehaviour
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
                Stats.shotgunAmmo += 20;
                character.SendMessage("PickAmmo", 3);
                Destroy(gameObject);
            }
        }
        catch (Exception) { }

    }
}
