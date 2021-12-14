using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.SetActive(true);
        StartCoroutine("wait");
    }

    public IEnumerator wait()
    {
        // animator.SetBool("isShooting", false);
        yield return new WaitForSeconds(5);
        panel.SetActive(false);
    }
}
