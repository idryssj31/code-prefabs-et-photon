using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monstercollision : MonoBehaviour
{
    //la condition lorsque je recois des degats
    bool isInvincible = false;
    //la variable pour faire clignoter notre perso
    public SkinnedMeshRenderer rend;
    public SkinnedMeshRenderer rend1;


    private void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "hurt") // on a touché une personne
        {
            Destroy(other.gameObject);
        }*/

        //pour le score de fin
        if(other.gameObject.name == "Fin")
        {
            print("Nombre de kill = " + PlayerInfo.pi.GetScore());
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        // Si la personne me touche
        if (collision.gameObject.tag == "monster" && !isInvincible)
        {

            // je suis blessé
            print("Aie !");
            isInvincible = true;
            PlayerInfo.pi.SetHealth(-1);
            //Destroy(collision.gameObject, 3f);
            //appel de la fonction que l'on vient de crée
            StartCoroutine("Resetinvincible");
        }
        //si on tombe dans le vide
        if(collision.gameObject.tag == "fall")
        {
            // on appel la fonction juste en bas
            StartCoroutine("RestartScene");
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Resetinvincible()
    {
        
        //lorsqu'on perds des points de vie .. puis on n'en gagne
        for(int i=0; i<5; i++)
        {
            rend1.material.color = Color.red;
            rend.material.color = Color.red;
            yield return new WaitForSeconds(.2f);
            rend
                .material.color = new Color32(250, 249, 247, 255);
            rend1.material.color = new Color32(207, 137, 219, 255);
            //si il est actif on le desactive
            rend.enabled = !rend.enabled;
            rend1.enabled = !rend1.enabled;
        }
        yield return new WaitForSeconds(.2f);
        rend.enabled = true;
        rend1.enabled = true;
        isInvincible = false;
    }

    





}
