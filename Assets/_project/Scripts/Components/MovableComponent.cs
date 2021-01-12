using Unity.Entities;
using Unity.Mathematics;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct MovableComponent : IComponentData
    {
        public float Speed;
        public float3 Direction;
    }
}
