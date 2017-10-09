using System.Threading;
using LiteNetLib;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;
using Logger = BrutalHack.Aleron.Shared.Util.Logger;

namespace BrutalHack.Aleron.GameClient.Network
{
    public class NetGameClient
    {
        private static NetGameClient _instance;
        private NetEventListener _netEventListener;
        private NetManager _netManager;

        public static NetGameClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NetGameClient();
                }
                return _instance;
            }
        }

        private NetGameClient()
        {
            _netEventListener = new NetEventListener();
            _netManager = new NetManager(_netEventListener, "aleron_connection");
            _netManager.Start();
            _netManager.UpdateTime = 15;
        }

        ~NetGameClient()
        {
            _netManager.Stop();
        }


        public void HandlePeer(float deltaTime)
        {
            NetPeer peer = _netManager.GetFirstPeer();
            if (peer != null && peer.ConnectionState == ConnectionState.Connected)
            {
//                Logger.Log("We have a peer!");
            }
            else
            {
                _netManager.SendDiscoveryRequest(new byte[] {1}, 5000);
                Logger.Log("Sent Discovery Request");
            }
        }

        public void PollEvents()
        {
            _netManager.PollEvents();
        }


        public bool IsConnectedToServer()
        {
            return _netManager.PeersCount == 1;
        }

        public void ConnectToServer(NetEndPoint remoteEndPoint)
        {
            _netManager.Connect(remoteEndPoint);
            Logger.Log("Connecting");
        }
    }
}