using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoadScene : MonoBehaviour
{
    // Start is called before the first frame update

    public Character character;
    public Weapon pistol;
    public Weapon rifle;
    public Weapon shotgun;
    public Weapon grenadeLauncher;
    public HealthBar healthBar;
    public Ammo _ammo;
    public Points _points;
    void Start()
    {
        character.health = Stats.currHp;
        pistol.ammo = Stats.pistolAmmo;
        rifle.ammo = Stats.rifleAmmo;
        shotgun.ammo = Stats.shotgunAmmo;
        pistol.currAmmo = Stats.pistolcurrAmmo;
        rifle.currAmmo = Stats.riflecurrAmmo;
        shotgun.currAmmo = Stats.shotguncurrAmmo;
        grenadeLauncher.ammo = Stats.grenadeLauncherAmmo;
        grenadeLauncher.currAmmo = Stats.grenadeLaunchercurrAmmo;
        character.points = Stats.score;

        healthBar.SetHealth(character.health);
        //_ammo.SetAmmo(pistol.currAmmo, pistol.ammo);
        _points.SetPoints(character.points);
    }
}
