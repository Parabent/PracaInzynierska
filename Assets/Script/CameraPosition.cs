using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform player;
    public Vector3 v3;
    public Vector3 boundsMax;
    public Vector3 boundsMin;

    void Update()
    {
        v3.x = player.position.x;
        v3.y = player.position.y;
        v3.z = -10;
        transform.position = new Vector3(Mathf.Clamp(v3.x, boundsMin.x, boundsMax.x),
            Mathf.Clamp(v3.y, boundsMin.y, boundsMax.y),
            v3.z);
    }

}
