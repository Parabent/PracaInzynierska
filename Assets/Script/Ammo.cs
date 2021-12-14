using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public Text text;

    public void SetAmmo(int currAmmo, int ammo)
    {
        text.text = "Ammo: " + Convert.ToString(currAmmo)+"/"+Convert.ToString(ammo);
    }


}
