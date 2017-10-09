using BrutalHack.Aleron.GameClient.Model.Systems;
using BrutalHack.Aleron.GameClient.Network;
using Entitas;
using LiteNetLib;
using NUnit.Framework.Internal;
using UnityEngine;
using Logger = BrutalHack.Aleron.Shared.Util.Logger;

namespace BrutalHack.Aleron.GameClient
{
    public class GameClientApplication
    {
        private static Contexts _contexts;
        private static Systems _systems;
        private NetGameClient _netGameClient;
        public static Transform TestObject { get; set; }

        public GameClientApplication()
        {
            _contexts = Contexts.sharedInstance;
            _systems = CreateSystems(_contexts);
            _netGameClient = NetGameClient.Instance;
            _systems.Initialize();
            Logger.Log("Systems initialized");
        }

        private Systems CreateSystems(Contexts contexts)
        {
            return new Feature("Client Systems")
                .Add(new TestSystem(contexts));
        }

        public void Update(float deltaTime)
        {
            _netGameClient.PollEvents();
            _systems.Execute();
            _netGameClient.HandlePeer(deltaTime);
        }
    }
}