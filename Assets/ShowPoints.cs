using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowPoints : MonoBehaviour
{
    public TMP_Text text;

    private void Awake()
    {
        text.text = "Wynik: " + Stats.score;
    }
}
