using System;
using Entitas;

namespace BrutalHack.Aleron.Shared.Model.Components
{
    [Client]
    [Server]
    [Serializable]
    public class DummyComponent : IComponent
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
}