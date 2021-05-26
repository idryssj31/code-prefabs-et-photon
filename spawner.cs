using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject projectile;
    

    private void Update()
    {
        if (Input.GetKey("v"))
        {
            GameObject Sphere = Instantiate(projectile, transform);
            Rigidbody rb = Sphere.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 20;
            //AxeThrow();
        }
    }

    /*public void AxeThrow()
    {
        axeRb.isKinematic = false;
        axeRb.transform.parent = null;
        axeRb.AddForce(transform.forward * throwPower, ForceMode.Impulse);

    }*/
}
