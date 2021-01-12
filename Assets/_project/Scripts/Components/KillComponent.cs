using Unity.Entities;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct KillComponent : IComponentData
    {
        public float Timer;
    }
}
