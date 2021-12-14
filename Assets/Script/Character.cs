using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public HealthBar healthBar;
    public Ammo _ammo;
    public Points _points;
    public Weapon weapon;
    public Shooting shooting;
    public Weapons weapons;
    public Movement movement;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    AudioSource shooting_sound;
    AudioClip sound;
    RelSound relsound;
    public float maxHealth = 100f;
    public float health;
    public int damage;
    public int ammo = 0;
    public int points;
    public int currAmmo;
    public int magazineSize;
    private bool isInvulnerable;
    private bool isSprint;
    private float isInvulnerableCD = 0f;
    private float isSprintCD = 0f;
    private float duration = 0f;
    private float sDuration = 0f;
    public static int weaponIndex = 1;

    void Start()
    {
        shooting_sound = GetComponent<AudioSource>();
        relsound = GameObject.FindGameObjectWithTag("ReloadSound").GetComponent<RelSound>();

        isInvulnerable = false;
        isSprint = false;
        health = maxHealth;
        points = Stats.score;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator.SetBool("isPistol", true);
        weapon = GameObject.FindGameObjectWithTag("Pistol").GetComponent<Weapon>();
        weapon.currAmmo = Stats.pistolcurrAmmo;
        weapon.ammo = Stats.pistolAmmo;
        weaponIndex = 1;
        ChangeWeapon();


        healthBar.SetMaxHealth(maxHealth);
        _ammo.SetAmmo(currAmmo, ammo);
        _points.SetPoints(this.points);
        weapons.SendMessage("SetWeaponName", "Pistol");
    }

    private void Update()
    {
        weapon.currAmmo = currAmmo;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (duration <= Time.time && isInvulnerable == false)
            {
                Invulnerable();
                isInvulnerableCD = 10f;
                duration = Time.time + isInvulnerableCD;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (sDuration <= Time.time && isSprint == false)
            {
                Sprint();
                isSprintCD = 10f;
                sDuration = Time.time + isSprintCD;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("isPistol", true);
            animator.SetBool("isRifle", false);
            animator.SetBool("isShotgun", false);

            weapon.ammo = ammo;
            weapon.currAmmo = currAmmo;
            weapon = GameObject.FindGameObjectWithTag("Pistol").GetComponent<Weapon>();

            sound = weapon.GetComponent<Weapon>().getsound();
            shooting_sound.clip = sound;
            weaponIndex = 1;
            weapon.ammo = Stats.pistolAmmo;
            //weapon.currAmmo = Stats.pistolcurrAmmo;
            ChangeWeapon();
            shooting.SendMessage("IsShotgun", false);
            weapons.SendMessage("SetWeaponName", "Pistol");
            _ammo.SetAmmo(currAmmo, ammo);
            spriteRenderer.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetBool("isPistol", false);
            animator.SetBool("isRifle", true);
            animator.SetBool("isShotgun", false);

            weapon.ammo = ammo;
            weapon.currAmmo = currAmmo;
            weapon = GameObject.FindGameObjectWithTag("Rifle").GetComponent<Weapon>();

            sound = weapon.GetComponent<Weapon>().getsound();
            shooting_sound.clip = sound;
            weaponIndex = 2;
            weapon.ammo = Stats.rifleAmmo;
            //weapon.currAmmo = Stats.riflecurrAmmo;
            ChangeWeapon();
            shooting.SendMessage("IsShotgun", false);
            weapons.SendMessage("SetWeaponName", "Rifle");
            _ammo.SetAmmo(currAmmo, ammo);
            spriteRenderer.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetBool("isPistol", false);
            animator.SetBool("isRifle", false);
            animator.SetBool("isShotgun", true);

            weapon.ammo = ammo;
            weapon.currAmmo = currAmmo;
            weapon = GameObject.FindGameObjectWithTag("Shotgun").GetComponent<Weapon>();

            sound = weapon.GetComponent<Weapon>().getsound();
            shooting_sound.clip = sound;
            weaponIndex = 3;
            weapon.ammo = Stats.shotgunAmmo;
            //weapon.currAmmo = Stats.shotguncurrAmmo;
            ChangeWeapon();
            shooting.SendMessage("IsShotgun", true);
            weapons.SendMessage("SetWeaponName", "Shotgun");
            _ammo.SetAmmo(currAmmo, ammo);
            spriteRenderer.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetBool("isPistol", false);
            animator.SetBool("isRifle", false);
            animator.SetBool("isShotgun", true);

            weapon.ammo = ammo;
            weapon.currAmmo = currAmmo;
            weapon = GameObject.FindGameObjectWithTag("GrenadeLauncher").GetComponent<Weapon>();

            sound = weapon.GetComponent<Weapon>().getsound();
            shooting_sound.clip = sound;
            weaponIndex = 4;
            weapon.ammo = Stats.grenadeLauncherAmmo;
            //weapon.currAmmo = Stats.shotguncurrAmmo;
            ChangeWeapon();
            shooting.SendMessage("IsShotgun", false);
            weapons.SendMessage("SetWeaponName", "GrenadeLauncher");
            _ammo.SetAmmo(currAmmo, ammo);
            spriteRenderer.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        }

    }
    public void ChangeWeapon()
    {
        currAmmo = weapon.currAmmo;
        Debug.Log(weapon.name);
        Debug.Log(weapon.currAmmo);
        Debug.Log(currAmmo);
        ammo = weapon.ammo;
        damage = weapon.damage;
        shooting.SendMessage("SetCooldown", weapon.cooldown);

    }
    public void Reload()
    {
        if (currAmmo == weapon.magazineSize)
        {
            return;
        }
        if (weapon.name == "Pistol")
        {
            animator.Play("Pistol_Reload");
        }
        if (weapon.name == "Rifle")
        {
            animator.Play("Rifle_Reload", 0, 0);
        }
        if (weapon.name == "Shotgun" || weapon.name == "GrenadeLauncher")
        {
            animator.Play("Shotgun_Reload");
        }
        relsound.SendMessage("Play");
        weapon.SendMessage("Reload", currAmmo);
        currAmmo = weapon.currAmmo;
        ammo = weapon.ammo;
        _ammo.SetAmmo(currAmmo, ammo);

    }
    public void Invulnerable()
    {
        isInvulnerable = true;
        StartCoroutine("InvCooldown");
        Debug.Log("Wylaczono");
    }
    public void Sprint()
    {
        isSprint = true;
        movement.SendMessage("SetMoveSpeed", true);
        StartCoroutine("SprintCooldown");
        Debug.Log("Wylaczono");
    }
    public IEnumerator InvCooldown()
    {
        yield return new WaitForSeconds(5);
        isInvulnerable = false;
    }
    public IEnumerator SprintCooldown()
    {
        yield return new WaitForSeconds(5);
        isSprint = false;
        movement.SendMessage("SetMoveSpeed", false);
    }

    public void TakeDamage(float damage)
    {
        if (!isInvulnerable)
        {
            health -= damage;
            healthBar.SetHealth(health);
            if(points>10 && damage>1)
            {
                points -= 10;
            }
            else if(damage<=1 && points >=1)
            {
                points -= 1;
            }
            else
            {
                points = 0;
            }
            Stats.currHp = health;
            _points.SetPoints(points);
        }
        if (health <= 0)
        {
            Die();
        }
    }
    public void PickAmmo(int weapon)
    {
        if (weapon == 1 && this.weapon.name == "Pistol")
        {
            this.weapon.ammo = Stats.pistolAmmo;
            
        }
        if (weapon == 2 && this.weapon.name == "Rifle")
        {
            this.weapon.ammo = Stats.rifleAmmo;

        }
        if (weapon == 3 && this.weapon.name == "Shotgun")
        {
            this.weapon.ammo = Stats.shotgunAmmo;

        }
        if(weapon == 4 && weaponIndex == 4)
        {
            this.weapon.ammo = Stats.grenadeLauncherAmmo;
        }
        ammo = this.weapon.ammo;
        _ammo.SetAmmo(currAmmo, ammo);

    }
    public void AddPoints(int points)
    {
        this.points += points;
        _points.SetPoints(this.points);
    }

    public void Heal(int health)
    {
        if (this.health <= maxHealth)
        {
            if ((this.health + health) <= maxHealth)
            {
                this.health += health;
                healthBar.SetHealth(this.health);
            }
            else
            {
                this.health = maxHealth;
            }
            Stats.currHp = this.health;

        }

    }
    void Die()
    {
        Cursor.visible = true;
        Destroy(gameObject, 0.2f);  
        SceneManager.LoadScene("GameOver");
        //UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}