using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disactivate : MonoBehaviour
{
    public GameObject[] toDisactivate;
    public GameObject[] toActivate;

    public void SetDisactivate()
    {
        foreach(GameObject gameObject in toDisactivate)
        {
            gameObject.SetActive(false);
        }
        foreach (GameObject gameObject in toActivate)
        {
            gameObject.SetActive(true);
        }

    }
    public void SetActive()
    {
        foreach (GameObject gameObject in toDisactivate)
        {
            gameObject.SetActive(true);
        }
        foreach (GameObject gameObject in toActivate)
        {
            gameObject.SetActive(false);
        }
    }
}
