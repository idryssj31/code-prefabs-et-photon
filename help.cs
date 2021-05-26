using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class help : MonoBehaviour
{
    GameObject cage;
    public Text infoTxt;
    bool canOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cage")
        {
            cage = other.gameObject;
            infoTxt.text = "Appuyes sur G pour ouvrir le coffre....";
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cage")
        {
            cage = null;
            infoTxt.text = "";
            canOpen = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G) && canOpen)
        {
            PauseScript.butinrestants--;
            Destroy(cage, 1.2f);
        }
    }


}
