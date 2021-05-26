using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void LoadLevel1()
    {
        //charger la partie "jouer"
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        //quitter l'application
        Application.Quit();
    }

    public void OpenSite(string url)
    {
        Application.OpenURL(url);
    }

}
