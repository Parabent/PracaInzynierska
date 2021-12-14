using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : MonoBehaviour
{
    Vector3 localScale;
    void Start()
    {
        localScale = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = gameObject.GetComponentInParent<Enemy>().health / gameObject.GetComponentInParent<Enemy>().maxHealth; 
        transform.localScale = localScale;
    }
}
