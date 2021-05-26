using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
 
    public static PlayerInfo pi;

    public int playerHealth = 5;
    public int nbkill = 0;
    //type de engine .ui
    public Image[] heart;
    public Text nbkillText;
    public Text scoreText;
    public checkpointMgr chkp;

    //patern notre variable egal a cette classe
    private void Awake()
    {
        pi = this;        
    }

    // void ne retourne pas de valeur cette fctn nous permettra de mettre a jour la quantité de vie
    public void SetHealth(int val)
    {
        playerHealth += val;
        if (playerHealth > 5)
            playerHealth = 5;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            chkp.Respawn();
        }
            

        SetHealthBar();
    }

    public void Getkill()
    {
        nbkill++;
        nbkillText.text = nbkill.ToString();//on convertie nombre en texte
    }

    //fonctino pour la barre de vie
    public void SetHealthBar()
    {
        //on vide la barre de vie
        foreach(Image img in heart)
        {
            img.enabled = false;
        }
        //on met le bon nombre de coeur a l ecran

        for (int i = 0; i <playerHealth; i++)
        {
            heart[i].enabled = true;
        }
    }

    //fonction pour la fin de la game affichage des stats

    public int GetScore()
    {
        int scoreFinal = (nbkill); //+ (playerHealth);
        //on calcul le score de fin
        scoreText.text = "Score kill = " + scoreFinal;
        
        return scoreFinal;
    }


}
