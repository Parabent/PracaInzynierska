using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    public Text text;

    public void SetWeaponName(string name)
    {
        text.text = name;
    }
}
