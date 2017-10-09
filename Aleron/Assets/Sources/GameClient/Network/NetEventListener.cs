using System;
using BrutalHack.Aleron.Shared.Model.Components;
using LiteNetLib;
using LiteNetLib.Utils;
using UnityEngine;
using Logger = BrutalHack.Aleron.Shared.Util.Logger;

namespace BrutalHack.Aleron.GameClient.Network
{
    public class NetEventListener : INetEventListener
    {
        private NetSerializer _netSerializer;

        public NetEventListener()
        {
            _netSerializer = new NetSerializer();
            _netSerializer.SubscribeReusable<DummyComponent, NetPeer>(OnDummyPackageReceived);
        }

        private void OnDummyPackageReceived(DummyComponent dummy, NetPeer peer)
        {
            Contexts.sharedInstance.client.CreateEntity().AddDummy(dummy.Value, dummy.Name);
        }

        public void OnNetworkReceiveUnconnected(NetEndPoint remoteEndPoint, NetDataReader reader,
            UnconnectedMessageType messageType)
        {
            Logger.Log("Discovery Response from " + remoteEndPoint);
            if (messageType == UnconnectedMessageType.DiscoveryResponse &&
                !NetGameClient.Instance.IsConnectedToServer())
            {
                NetGameClient.Instance.ConnectToServer(remoteEndPoint);
            }
        }

        public void OnNetworkReceive(NetPeer peer, NetDataReader reader)
        {
            _netSerializer.ReadAllPackets(reader, peer);
        }

        public void OnPeerConnected(NetPeer peer)
        {
            Logger.Log("Peer connected: " + peer.EndPoint);
        }

        public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            Logger.Log("Peer disconnected: " + peer.EndPoint);
        }

        public void OnNetworkError(NetEndPoint endPoint, int socketErrorCode)
        {
            Logger.Log("error " + socketErrorCode);
        }

        public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
        {
        }
    }
}