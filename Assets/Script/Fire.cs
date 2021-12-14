using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pos;
    public float period = 0.0f;
    public GameObject firePrefab;
    public bool alwaysFire = false;
    public  int fireDelay = 2;
    private void Start()
    {
        if(alwaysFire)
        {
            ShowFire(1000);
        }
    }
    private void Update()
    {
        if(!alwaysFire)
        {
            if (period > 3.5f)
            {
                ShowFire(fireDelay);
                period = 0;
            }
            period += UnityEngine.Time.deltaTime;
        }


    }

    void ShowFire(int FireDelay)
    {
        GameObject fire = Instantiate(firePrefab, pos.position, pos.rotation);
        //Rigidbody2D rb = fire.GetComponent<Rigidbody2D>();
        //rb.isKinematic = false;
        Destroy(fire, FireDelay);

    }
}
