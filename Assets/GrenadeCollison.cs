using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GrenadeCollison : MonoBehaviour
{
    private float countDown;
    private bool hasExplosed;

    public GameObject ExplosionEffect;
    public float Delay = 0.5f;
    public float GrenadeRadius = 0.05f;
    public float ExplosionForce = 0.05f;

    void Start()
    {
        countDown = Delay;

    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0f && !hasExplosed)
        {
            Explode();
            hasExplosed = true;
        }
    }

    private void Explode()
    {
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Collider2D[] touchedObjects = Physics2D.OverlapCircleAll(transform.position, GrenadeRadius).Where(x => x.tag == "Enemy").ToArray();

        foreach (Collider2D touchedObject in touchedObjects)
        {
            Rigidbody rigidbody = touchedObject.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(ExplosionForce, transform.position, GrenadeRadius);
            }

            var target = touchedObject.gameObject.GetComponent<Enemy>();
            target.TakeDamage(100);

        }
        Destroy(gameObject);
    }
}
