using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossScript : MonoBehaviour
{
    private Vector2 movement;
    public Rigidbody2D rb;
    int Direction = -1;
    public float fMinX;
    public float fMaxX;
    public float fMinY;
    public float fMaxY;
    public float moveSpeed = 20f;
    private EnemyShooting enemyShooting;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Enemy enemy;
    public float bulletForce = 20f;
    public float period = 0.0f;
    int rand;
    void Start()
    {
        gameObject.SetActive(false);
        fMinX = rb.position.x;
        fMaxX = rb.position.x + 4.5f;
        fMinY = rb.position.y;
        fMaxY = rb.position.y + 8;
        rand = Random.Range(1, 5);
        Debug.Log(rand);
    }

    // Update is called once per frame
    void Update()
    {

        if (rand == 1)
        {

            switch (Direction)
            {
                case -1:
                    if (rb.position.x <= fMaxX)
                    {
                        movement.y = 0f;
                        movement.x = 1f;
                    }
                    else
                    {
                        //Shoot();
                        rand = Random.Range(1, 5);
                        Debug.Log(rand);
                        Direction = -1;
                    }
                    break;

            }
        }
        if (rand == 2)
        {
            switch (Direction)
            {
                case -1:
                    if (rb.position.y <= fMaxY)
                    {
                        movement.x = 0f;
                        movement.y = 1f;
                    }
                    else
                    {
                        Shoot();
                        Direction = 2;
                    }
                    break;
                case 2:
                    if (rb.position.y >= fMinY)
                    {
                        movement.x = 0f;
                        movement.y = -1f;
                    }
                    else
                    {
                        Shoot();
                        rand = Random.Range(1, 5);
                        Debug.Log(rand);
                        Direction = -1;

                    }
                    break;
            }

        }
        if (rand == 3)
        {
            switch (Direction)
            {
                case -1:
                    if (rb.position.y >= fMinY - 8)
                    {
                        movement.x = 0f;
                        movement.y = -1f;
                    }
                    else
                    {
                        Shoot();
                        Direction = 2;
                    }
                    break;
                case 2:
                    if (rb.position.y <= fMinY)
                    {
                        movement.x = 0f;
                        movement.y = 1f;
                    }
                    else
                    {
                        Shoot();
                        rand = Random.Range(1, 5);
                        Debug.Log(rand);
                        Direction = -1;

                    }
                    break;
            }
        }
        if(rand == 4)
        {
            if (rb.position.x >= fMinX)
            {
                movement.y = 0f;
                movement.x = -1.0f;
            }
            else
            {
                //Shoot();
                rand = Random.Range(1, 5);
                Debug.Log(rand);
                Direction = -1;

            }
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void Shoot()
    {
        bulletPrefab.GetComponent<Bullet>().damage = enemy.damage;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5);
    }
    public IEnumerator wait()
    {
        Debug.Log("dziala");
        yield return new WaitForSeconds(3);
    }

}
