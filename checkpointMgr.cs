using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointMgr : MonoBehaviour
{
    public Vector3 lastPoint;
    // Start is called before the first frame update
    void Start()
    {
        lastPoint = transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "checkpoint")
        {
            lastPoint = transform.position;
            //activer le script de rotation du diamant
            other.gameObject.GetComponent<anim>().enabled = true;
        }
    }

    public void Respawn()
    {
        transform.position = lastPoint;
        PlayerInfo.pi.SetHealth(5);
    }

}
