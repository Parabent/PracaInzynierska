using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int counter;
    public int targetCounter;

    // Update is called once per frame
    void Update()
    {
        if(counter >= targetCounter)
        {
            Destroy(gameObject, 1f);
        }
    }
    public void AddCounter()
    {
        counter++;
    }
}
