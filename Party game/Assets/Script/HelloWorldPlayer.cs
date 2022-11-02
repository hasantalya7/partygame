using Unity.Netcode;
using UnityEngine;

    public class HelloWorldPlayer : NetworkBehaviour
    {
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            Move();
        }
        
    }
    private void Start()
    {
            NetworkManager.Singleton.transform.position = new Vector3(0, 2, 0);
    }
    void Update()
        {
            transform.position = Position.Value;
        }

    void Move()
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");
                Position.Value = new Vector3(transform.position.x + horizontalInput * 5 * Time.deltaTime, 0, transform.position.z + verticalInput * 5 * Time.deltaTime);             
                
        /*
                if (movementDirection != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 400 * Time.deltaTime);
                }*/
            }
    [ServerRpc]
    void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
    {
        Position.Value = GetRandomPositionOnPlane();
    }
    Vector3 GetRandomPositionOnPlane()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        return new Vector3(transform.position.x + horizontalInput * 5 * Time.deltaTime, 0, transform.position.z + verticalInput * 5 * Time.deltaTime);
    }


}