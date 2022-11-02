
using Unity.Netcode;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using Unity.Netcode.Transports.UTP;

namespace HelloWorld
{
    public class HelloWorldManager : NetworkBehaviour 
    {
        public static string GetIPAddress()
        {
            IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName()).Where(address =>
            address.AddressFamily == AddressFamily.InterNetwork).First();
            return ip.ToString();
        }

        private void Start()
        {

            if(!NetworkManager.Singleton.IsHost)
            {
                NetworkManager.GetComponent<UnityTransport>().ConnectionData.Address = GetIPAddress();
                NetworkManager.Singleton.StartHost();
                
            }
            else
            {
                NetworkManager.Singleton.StartClient();
            }
        }
    }
}