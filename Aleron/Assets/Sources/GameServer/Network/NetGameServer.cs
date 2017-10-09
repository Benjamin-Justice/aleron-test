using System.Collections.Generic;
using BrutalHack.Aleron.Shared.Model.Components;
using BrutalHack.Aleron.Shared.Util;
using LiteNetLib;
using LiteNetLib.Utils;

namespace BrutalHack.Aleron.GameServer.Network
{
    public class NetGameServer
    {
        private NetDataWriter _dataWriter;
        private NetManager _netManager;
        private static NetGameServer _instance;
        private List<NetPeer> _netPeers;
        private NetSerializer _netSerializer;
        private INetEventListener _netEventListener;
        private int _i;

        public static NetGameServer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NetGameServer();
                }
                return _instance;
            }
        }

        private NetGameServer()
        {
            _netPeers = new List<NetPeer>();
            _dataWriter = new NetDataWriter();
            _netEventListener = new NetEventListener();
            _netManager = new NetManager(_netEventListener, 100, "aleron_connection");
            _netManager.Start(5000);
            _netManager.DiscoveryEnabled = true;
            _netManager.UpdateTime = 15;
            Logger.Log("Server started.");
            _netSerializer = new NetSerializer();
        }

        ~NetGameServer()
        {
            _netManager.Stop();
        }

        public void PollEvents()
        {
            _netManager.PollEvents();
        }

        public void HandlePeer(float deltaTime)
        {
            foreach (NetPeer netPeer in _netPeers)
            {
                _dataWriter.Reset();
                DummyComponent dummyComponent = new DummyComponent
                {
                    Name = "Hello",
                    Value = _i++
                };
                _dataWriter.Put(_netSerializer.Serialize(dummyComponent));
                netPeer.Send(_dataWriter, SendOptions.Unreliable);
            }
        }


        public void AddPeer(NetPeer peer)
        {
            _netPeers.Add(peer);
        }

        public void SendDiscoveryResponse(NetEndPoint remoteEndPoint)
        {
            _netManager.SendDiscoveryResponse(new byte[] {1}, remoteEndPoint);
        }

        public bool RemovePeer(NetPeer peer)
        {
            return _netPeers.Remove(peer);
        }
    }
}