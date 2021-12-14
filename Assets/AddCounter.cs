using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;

    private void OnDestroy()
    {
        IncreaseCounter();
    }
    public void IncreaseCounter()
    {
        if(door!=null)
        {
            door.SendMessage("AddCounter");
        }
        
    }
}
