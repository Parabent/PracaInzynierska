using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = true;
    }
    public void Play()
    {
        Stats.currStage = 2;
        Stats.currStage++;
        SceneManager.LoadScene(Stats.currStage);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void ResetStats()
    {
        Stats.currHp = 200;
        Stats.pistolAmmo = 1000;
        Stats.rifleAmmo = 60;
        Stats.shotgunAmmo = 33;
        Stats.grenadeLauncherAmmo = 10;
    }
}

