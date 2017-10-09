using BrutalHack.Aleron.Shared.Util;
using LiteNetLib;
using LiteNetLib.Utils;

namespace BrutalHack.Aleron.GameServer.Network
{
    public class NetEventListener : INetEventListener
    {
        public void OnPeerConnected(NetPeer peer)
        {
            Logger.Log("Peer Connected: " + peer.ConnectId + ", " + peer.EndPoint);
            NetGameServer.Instance.AddPeer(peer);
        }

        public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            Logger.Log("Peer Disconnected: " + peer.ConnectId + ", " + peer.EndPoint);
            Logger.Log("Reason: " + disconnectInfo);
            NetGameServer.Instance.RemovePeer(peer);
        }

        public void OnNetworkError(NetEndPoint endPoint, int socketErrorCode)
        {
            Logger.Log("error " + socketErrorCode);
        }

        public void OnNetworkReceive(NetPeer peer, NetDataReader reader)
        {
            Logger.Log("Received message from " + peer.EndPoint);
        }

        public void OnNetworkReceiveUnconnected(NetEndPoint remoteEndPoint, NetDataReader reader,
            UnconnectedMessageType messageType)
        {
            if (messageType == UnconnectedMessageType.DiscoveryRequest)
            {
                Logger.Log("Received discovery request. Send discovery response");
                NetGameServer.Instance.SendDiscoveryResponse(remoteEndPoint);
            }
        }

        public void OnNetworkLatencyUpdate(NetPeer peer, int latency)
        {
            //NOP
        }
    }
}