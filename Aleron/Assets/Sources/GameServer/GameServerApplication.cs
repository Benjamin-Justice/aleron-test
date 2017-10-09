using System;
using BrutalHack.Aleron.GameClient.Model.Systems;
using BrutalHack.Aleron.GameServer.Model;
using BrutalHack.Aleron.GameServer.Model.Systems;
using BrutalHack.Aleron.GameServer.Network;
using Entitas;
using JetBrains.Annotations;
using LiteNetLib;
using LiteNetLib.Utils;
using UnityEngine;
using Logger = BrutalHack.Aleron.Shared.Util.Logger;

namespace BrutalHack.Aleron.GameServer
{
    public class GameServerApplication
    {
        private Systems _systems;
        private ServerContext _serverContext;
        private NetGameServer _network;

        public GameServerApplication()
        {
            Contexts contexts = Contexts.sharedInstance;
            _serverContext = contexts.server;
            ServerEntity entity = _serverContext.CreateEntity();
            entity.AddDummy(0, "Hello");
            entity.isServer = true;
            _systems = CreateSystems(contexts);
            _network = NetGameServer.Instance;
        }


        public void Update(float deltaTime)
        {
            _network.PollEvents();
            _systems.Execute();
            _network.HandlePeer(deltaTime);
        }

        private Systems CreateSystems(Contexts contexts)
        {
            // ReSharper disable once JoinDeclarationAndInitializer
            Systems systems;
#if UNITY_5_3_OR_NEWER
            Logger.Log("Not Headless");
            systems = new Feature("Server Systems")
                .Add(new ServerTestSystem(contexts));
#else
            Logger.Log("Headless");
            systems = new Systems();
            systems.Add(new ServerTestSystem(contexts));
#endif
            return systems;
        }
    }
}