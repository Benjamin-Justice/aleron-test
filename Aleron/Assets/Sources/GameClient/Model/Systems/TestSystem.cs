using System;
using BrutalHack.Aleron.Shared.Util;
using Entitas;

namespace BrutalHack.Aleron.GameClient.Model.Systems
{
    public class TestSystem : IExecuteSystem
    {
        private readonly ClientContext _context;

        public TestSystem(Contexts contexts)
        {
            _context = contexts.client;
        }

        public void Execute()
        {
            IGroup<ClientEntity> allDummies = _context.GetGroup(ClientMatcher.Dummy);
            foreach (ClientEntity entity in allDummies.GetEntities())
            {
                Logger.Log(String.Format("Receiving Dummy: {0}, {1}", entity.dummy.Name, entity.dummy.Value));
                entity.RemoveDummy();
            }
        }
    }
}