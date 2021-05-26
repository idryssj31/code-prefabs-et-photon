using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    //savoir si notre jeu est en pause
    bool isPaused = false;

    public GameObject menuPause;
    public Text objectifs;
    public Text objectifs1;
    public static int monstrerestants = 5;
    public static int butinrestants = 2;
    public GameObject miniMap;
    

    public void SetObjectifText()
    {
        objectifs1.text = "Il reste " + monstrerestants + " monstres à tuer.";
        objectifs.text = "Il reste " + butinrestants + " coffre à ouvrir.";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                isPaused = false;
                menuPause.SetActive(isPaused);
                Time.timeScale = 1f;
            }
            else
            {
                SetObjectifText();
                isPaused = true;
                menuPause.SetActive(isPaused);
                Time.timeScale = 0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            miniMap.active = !miniMap.active;
        }
    }



}
