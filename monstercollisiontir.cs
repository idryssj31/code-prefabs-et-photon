using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monstercollisiontir : MonoBehaviour
{
    //la condition lorsque je recois des degats
    bool isInvincible = false;
    public int nbkill = 0;



    private void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((Input.GetKey("i") && other.gameObject.tag == "monster")) // on a touché une personne
        {
            nbkill++;
            //appel de notre fonction skill stict
            PlayerInfo.pi.Getkill();
            PauseScript.monstrerestants--;
            //Destroy(other, 1f);
            Destroy(other.gameObject);
            
        }
    }








}
