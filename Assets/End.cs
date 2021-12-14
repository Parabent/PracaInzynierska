using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneName;
    private Character character;
    public Weapon pistol;
    public Weapon rifle;
    public Weapon shotgun;
    public Weapon grenadeLauncher;
    void OnTriggerEnter2D(Collider2D collision)
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        try
        {
            if (collision.attachedRigidbody.name == "Character")
            {
                Stats.score = character.points;
                Stats.currHp = character.health;

                Stats.pistolAmmo = pistol.ammo;
                Stats.rifleAmmo = rifle.ammo;
                Stats.shotgunAmmo = shotgun.ammo;
                Stats.grenadeLauncherAmmo = grenadeLauncher.ammo;
                Stats.pistolcurrAmmo = pistol.currAmmo;
                Stats.riflecurrAmmo = rifle.currAmmo;
                Stats.shotguncurrAmmo = shotgun.currAmmo;
                Stats.grenadeLaunchercurrAmmo = grenadeLauncher.currAmmo;
                Debug.Log("obecny etap");
                Debug.Log("pistolcurrAmmo" + Stats.pistolcurrAmmo);
                Debug.Log("riflecurrAmmo" + Stats.riflecurrAmmo);
                Debug.Log("shotguncurrAmmo" + Stats.shotguncurrAmmo);
                Debug.Log("nastepny etap");

                Stats.currStage++;
                if(Stats.currStage == SceneManager.sceneCountInBuildSettings - 1)
                {
                    SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
               

            }
        }
        catch (Exception) { }

    }
}
