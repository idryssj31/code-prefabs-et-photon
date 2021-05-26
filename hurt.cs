using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurt : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "hurt") // on a touché une personne
        {
            Destroy(other.gameObject);
        }*/
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        // Si la personne me touche
        if(collision.gameObject.tag == "hurt")
        {
            // je suis blessé
            print("Aie !");
            //Destroy(collision.gameObject, 3f);
        }
    }



}
