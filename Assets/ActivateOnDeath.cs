using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public bool active;
    public Enemy boss;

    void Start()
    {
        //boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Enemy>();
    }
    void Update()
    {
        if(boss.health<=0)
        {
            obj.SetActive(active);
        }
    }
}
