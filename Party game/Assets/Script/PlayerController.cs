using Unity.Netcode;
using UnityEngine;


public class PlayerController : NetworkBehaviour
{
    private Vector3 move;
    private void Update()
    {
        if (IsOwner)
        {
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5 * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x - 5 * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }

    }
}