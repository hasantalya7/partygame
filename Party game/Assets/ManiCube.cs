using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class ManiCube : NetworkBehaviour
{
    [SerializeField] private Transform yokolanyer;
    [SerializeField] private Material ColorDestroy;
    public int count;
    private void Awake()
    {
        yokolanyer = gameObject.transform;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            count++;
            if(count>1)
            {
                GetComponent<MeshRenderer>().material = ColorDestroy;
                Invoke("yokol", 1f);
            }
        }
    }
    private void yokol()
    {
        yokolanyer.GetComponent<NetworkObject>().Despawn(true);
    }
}
