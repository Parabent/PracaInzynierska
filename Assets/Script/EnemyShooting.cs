using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Enemy enemy;
    private Transform target;
    public float bulletForce = 10f;
    public float period = 0.0f;
    public bool onShooting = true;
    private float maxDistance = 25;
    private float range;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);
        if (onShooting && range < maxDistance)
        {
            if (period > 1.5f)
            {
                Shoot();
                period = 0;
            }
            period += UnityEngine.Time.deltaTime;
        }
    }

    void Shoot()
    {
        bulletPrefab.GetComponent<Bullet>().damage = enemy.damage;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5);
    }
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
