using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePointL;
    public Transform firePointR;
    public GameObject bulletPrefab;
    public GameObject grenade;
    public float bulletForce = 10f;
    public Character character;
    public Ammo ammo;
    private bool cooldown = false;
    private float cd;
    private bool shotgun;
    public Animator animator;
    private bool isReloading = false;
    AudioSource shooting_sound;

    private void Start()
    {
        //anim = GetComponent<Animation>();
        shooting_sound = GetComponent<AudioSource>();
    }
    void Update()
    {
        GrenadeLauncherSpeed();
        if (Input.GetButtonDown("Fire1") && character.currAmmo > 0 && cooldown == false && isReloading == false && shotgun == false && character.ammo + character.currAmmo > 0)
        {
            if(Pause.isPaused)
            {
                return;
            }
            shooting_sound.Play();
            if (character.weapon.name == "Pistol")
            {
                animator.Play("Pistol_Shoot");
            }
            else if(character.weapon.name == "Rifle")
            {
                animator.Play("RifleShoot");
            }
            else
            {
                animator.Play("Shotgun_Shoot");
            }
            if(Character.weaponIndex ==4)
            {
                ShootGrenades(firePoint);
            }
            else
            {
                Shoot(firePoint);
            }
            cooldown = true;
            StartCoroutine("wait");
            character.currAmmo--;
            ammo.SetAmmo(character.currAmmo, character.ammo);

        }
        if (Input.GetButtonDown("Fire1") && character.currAmmo >= 3 && cooldown == false && isReloading == false && shotgun == true && character.ammo + character.currAmmo >= 3)
        {
            shooting_sound.Play();
            animator.Play("Shotgun_Shoot");
            animator.SetTrigger("Active");
            Shoot(firePoint);
            Shoot(firePointL);
            Shoot(firePointR);
            cooldown = true;
            StartCoroutine("wait");
            character.currAmmo -= 3;
            ammo.SetAmmo(character.currAmmo, character.ammo);
        }
        if (character.currAmmo == 0)
        {
            character.Reload();
            isReloading = true;
            StartCoroutine("WaitForReload");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            character.Reload();
            isReloading = true;
            StartCoroutine("WaitForReload");
        }

    }

    void Shoot(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5);
    }
    void ShootGrenades(Transform firePoint)
    {
        GameObject bullet = Instantiate(grenade, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    private void GrenadeLauncherSpeed()
    {
        if (character.weapon.name == "GrenadeLauncher")
        {
            bulletForce = 12f;
        }
        else
        {
            bulletForce = 25f;
        }
    }
    public void SetCooldown(float cooldown)
    {
        cd = cooldown;
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(cd);
        cooldown = false;
    }
    public IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(character.weapon.reloadTime);
        isReloading = false;
    }
    public void IsShotgun(bool shotgun)
    {
        this.shotgun = shotgun;
    }
}