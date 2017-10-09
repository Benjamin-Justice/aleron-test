using BrutalHack.Aleron.GameServer.Network;
using Entitas;
using UnityEngine;

namespace BrutalHack.Aleron.GameServer.Model.Systems
{
  public class ServerTestSystem : IExecuteSystem
  {
    private readonly ServerContext _contexts;

    public ServerTestSystem(Contexts contexts)
    {
      _contexts = contexts.server;
    }

    public void Execute()
    {
    }
  }
}