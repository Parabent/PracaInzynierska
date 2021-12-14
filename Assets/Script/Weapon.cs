using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int index;
    public int damage;
    public float cooldown;
    public int ammo;
    public int magazineSize;
    public int currAmmo;
    public float reloadTime;
    private AudioClip sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>().clip;
        Initiate();
    }
    public AudioClip getsound()
    {
        return sound;
    }
    public void Reload(int currAmmo)
    {
        Debug.Log("przeladowano");
        if(Character.weaponIndex == 1)
        {
            if (ammo < magazineSize)
            {
                this.currAmmo = ammo;
                ammo = 0;
                Stats.pistolcurrAmmo = this.currAmmo;
                Stats.pistolAmmo = 0;
            }
            else
            {
                ammo += currAmmo;
                this.currAmmo = magazineSize;
                ammo -= magazineSize;
                Stats.pistolcurrAmmo = this.currAmmo;
                Stats.pistolAmmo = ammo;
            }
        }
        if (Character.weaponIndex == 2)
        {
            if (ammo < magazineSize)
            {
                this.currAmmo = ammo;
                ammo = 0;
                Stats.riflecurrAmmo = this.currAmmo;
                Stats.rifleAmmo = 0;
            }
            else
            {
                ammo += currAmmo;
                this.currAmmo = magazineSize;
                ammo -= magazineSize;
                Stats.riflecurrAmmo = this.currAmmo;
                Stats.rifleAmmo = ammo;
            }
        }
        if (Character.weaponIndex == 3)
        {
            if (ammo < magazineSize)
            {
                this.currAmmo = ammo;
                ammo = 0;
                Stats.shotguncurrAmmo = this.currAmmo;
                Stats.shotgunAmmo = 0;
            }
            else
            {
                ammo += currAmmo;
                this.currAmmo = magazineSize;
                ammo -= magazineSize;
                Stats.shotguncurrAmmo = this.currAmmo;
                Stats.shotgunAmmo = ammo;
            }
        }
        if (Character.weaponIndex == 4)
        {
            if (ammo < magazineSize)
            {
                this.currAmmo = ammo;
                ammo = 0;
                Stats.grenadeLaunchercurrAmmo = this.currAmmo;
                Stats.grenadeLauncherAmmo = 0;
            }
            else
            {
                ammo += currAmmo;
                this.currAmmo = magazineSize;
                ammo -= magazineSize;
                Stats.grenadeLaunchercurrAmmo = this.currAmmo;
                Stats.grenadeLauncherAmmo = ammo;
            }
        }



    }
    public void Initiate()
    {
            if (Stats.isLoaded<3)
            {
                //if (initiate == false)
                //{
                //    currAmmo = magazineSize;
                //    ammo -= magazineSize;
                //    initiate = true;
                //}
                if (gameObject.name == "Pistol")
                {
                    currAmmo = magazineSize;
                    ammo -= magazineSize;
                    Stats.pistolcurrAmmo = currAmmo;
                    Stats.isLoaded++;
                }
                if (gameObject.name == "Rifle")
                {
                currAmmo = magazineSize;
                    ammo -= magazineSize;
                    Stats.riflecurrAmmo = currAmmo;
                    Stats.isLoaded++;
                }
                if (gameObject.name == "Shotgun")
                {
        
                currAmmo = magazineSize;
                    ammo -= magazineSize;
                    Stats.shotguncurrAmmo = currAmmo;
                    Stats.isLoaded++;
                }
            if (gameObject.name == "GrenadeLauncher")
            {

                currAmmo = magazineSize;
                ammo -= magazineSize;
                Stats.shotguncurrAmmo = currAmmo;
                Stats.isLoaded++;
            }

        }

        
    }


}