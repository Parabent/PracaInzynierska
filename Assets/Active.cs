using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public bool active = false;
    void Start()
    {
        gameObject.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
