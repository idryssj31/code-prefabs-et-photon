using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{

    
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    public CharacterController cc;
    //variable pour le deplacement
    public float moveSpeed;
    public float jumpForce;
    public float gravity;


 
    //vecteur pour l'animation
    private Animator anim;
  



    //valeur dans le parametre de l'animator
    bool isWalking = false;
    bool isWalkingR = false;
    bool isWalkingL = false;
    bool isRunning = false;
    bool isJumping = false;
    bool isJumpingB = false;
    bool isSpeJumping = false;
    bool isRunningR = false;
    bool isRunningL = false;
    bool isRunningB = false;
    bool isWalkingB = false;
    bool isWall = false;

    //public AudioClip hitSound;
    //valeur pour le son en private
    //AudioSource audioSource;
    //activer l'effet ou non


    public class PlayAudio : MonoBehaviour
    {
        public AudioSource audioSource;

        void Start()
        {
            audioSource.Play();
        }
    }

    // aux lieux de mettre les variables en public est que ca surcharge l'inspector on fait ca
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();




        // musique


    }

    void Update()
    {
        if(photonView.IsMine)
        ProcessInput();
    }

    public void ProcessInput()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            cc.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }


        //conditin pour le saut
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            direction.y = jumpForce;
        }

        //tuto

        //on applique la gravité a notre perso pour qu'il retombe lorsqu'il saute
        direction.y -= gravity * Time.deltaTime;

        //condition sur si le perso se deplace ... on applique l'animation
        /*if(moveDir.x != 0 || moveDir.z != 0)*/

        //on applique le deplacement du perso
        cc.Move(direction * Time.deltaTime);




        //MOUV saut de devant animation
        if (Input.GetKey("t") && Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            isSpeJumping = true;
        }
        else
        {
            isSpeJumping = false;
        }

        //MOUV saut animation
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            isJumping = true;
            direction.y = jumpForce;
        }
        else
        {
            isJumping = false;
        }

        //MOUV saut de derriere animation
        if (Input.GetKey("r") && (Input.GetButtonDown("Jump") && cc.isGrounded))
        {
            isJumpingB = true;
            direction.z -= 1;
            direction.y = 0;
        }
        else
        {
            isJumpingB = false;

        }


        //MOUV devant animation
        if (Input.GetKey("t"))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }


        //MOUV derriere animation
        if (Input.GetKey("r"))
        {
            isWalkingB = true;
        }
        else
        {
            isWalkingB = false;
        }

        //MOUV droite animation
        if (Input.GetKey("e"))
        {
            isWalkingR = true;
        }
        else
        {
            isWalkingR = false;
        }

        //MOUV gauche animation
        if (Input.GetKey("a"))
        {
            isWalkingL = true;
        }
        else
        {
            isWalkingL = false;
        }

        //MOUV sprint devant animation
        if (Input.GetKey("t") && (Input.GetKey("b")))
        {
            isRunning = true;

        }
        else
        {
            isRunning = false;
            moveSpeed = 2;
        }

        //MOUV sprint derriere animation
        if (Input.GetKey("r") && (Input.GetKey("b")))
        {
            isRunningB = true;

        }
        else
        {
            isRunningB = false;
            moveSpeed = 2;
        }


        //MOUV sprint droit animation
        if (Input.GetKey("e") && (Input.GetKey("b")))
        {
            isRunningR = true;

        }
        else
        {
            isRunningR = false;
            moveSpeed = 2;
        }

        //MOUV sprint gauche animation
        if (Input.GetKey("a") && (Input.GetKey("b")))
        {
            isRunningL = true;

        }
        else
        {
            isRunningL = false;
            moveSpeed = 2;
        }

        //Mouvespeed
        if (isRunning || isRunningB || isRunningL || isRunningR == true)
        {
            moveSpeed += 2;
        }

        //animation Mur 
        if (Input.GetKey("v"))
        {

            isWall = true;


        }
        else
        {
            isWall = false;
        }




        //WALL CREATION COMPETENCE





        //appel des animations
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isJumpingB", isJumpingB);
        anim.SetBool("isSpeJumping", isSpeJumping);
        anim.SetBool("isWalkingB", isWalkingB);
        anim.SetBool("isRunningR", isRunningR);
        anim.SetBool("isRunningL", isRunningL);
        anim.SetBool("isRunningB", isRunningB);
        anim.SetBool("isWalkingR", isWalkingR);
        anim.SetBool("isWalkingL", isWalkingL);
        anim.SetBool("isWall", isWall);


    }
}


