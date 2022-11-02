using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class test : NetworkBehaviour
{
    [SerializeField] private Transform yokolanyer;
    [SerializeField] private Material ColorDestroy;
    private void Awake()
    {
        yokolanyer = gameObject.transform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            GetComponent<MeshRenderer>().material = ColorDestroy;
            Invoke("yokol", 1f);
            
        }
    }
    private void yokol()
    {
        yokolanyer.GetComponent<NetworkObject>().Despawn(true);
    }
}
