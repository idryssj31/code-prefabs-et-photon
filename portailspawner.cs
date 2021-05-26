using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portailspawner : MonoBehaviour
{
    public GameObject tirr;


    private void Update()
    {
        if (Input.GetKey("i"))
        {


            GameObject Tir = Instantiate(tirr, transform);
            Rigidbody rb = Tir.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 20;
        }
    }
}