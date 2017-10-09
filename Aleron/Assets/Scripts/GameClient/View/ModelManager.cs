using BrutalHack.Aleron.GameServer;
using UnityEngine;

namespace BrutalHack.Aleron.GameClient.View
{
    public class ModelManager : MonoBehaviour
    {
        public bool RunGameServer = true;
        public Transform TestObject;
        private GameServerApplication _gameServerApplication;
        private GameClientApplication _gameClientApplication;

        private void Start()
        {
            //TODO start loginserver
            Debug.Log("Starting Game Server and Client Model");
            if (RunGameServer)
            {
                StartServerModel();
            }
            StartClientModel();
        }

        private void StartClientModel()
        {
            _gameClientApplication = new GameClientApplication();
            GameClientApplication.TestObject = TestObject;
            Debug.Log("Startet Client Model.");
        }

        private void StartServerModel()
        {
            _gameServerApplication = new GameServerApplication();
        }

        void Update()
        {
            float deltaTime = Time.deltaTime;
            _gameClientApplication.Update(deltaTime);
            if (RunGameServer)
            {
                _gameServerApplication.Update(deltaTime);
            }
        }

        void OnDestroy()
        {
            _gameClientApplication = null;
            if (RunGameServer)
            {
                _gameServerApplication = null;
            }
        }
    }
}