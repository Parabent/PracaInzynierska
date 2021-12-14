using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Play()
    {
        SceneManager.LoadScene(Stats.currStage);
    }
}
