using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercollision : MonoBehaviour
{
    public GameObject pickupEffect;
    public AudioClip hitSound;
    //valeur pour le son en private
    AudioSource audioSource;
    //activer l'effet ou non
    bool canInstantiate = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin") // on a touché une pièce
        {
            audioSource.PlayOneShot(hitSound);
            GameObject go = Instantiate(pickupEffect, other.transform.position, Quaternion.identity);
            Destroy(go, 4f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "hurt" /*&& canInstantiate*/) // on a touché une pièce
        {
            audioSource.PlayOneShot(hitSound);
            //canInstantiate = false;
            //jouer un son une fois
            
            
            GameObject go = Instantiate(pickupEffect, other.transform.position, Quaternion.identity);
            Destroy(go, 4f);
            Destroy(other.gameObject);
            //metttre en paue le programme
            //StartCoroutine("ResetInstantiate");
        }


    //mettre en  pause le programme
    /*IEnumerator ResetInstantiate()
        {
         yield return new WaitForSeconds(0.8f);
         canInstantiate = true;
        }*/



    }

}
