using Unity.Entities;
using Unity.Mathematics;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct FollowComponent : IComponentData
    {
        public Entity Target;
        public float3 Offset;

        public float Distance;

        public float MoveSpeed;
        public float MoveRotation;

        public bool ShouldFreezeX;
        public bool ShouldFreezeY;
        public bool ShouldFreezeZ;
        public bool ShouldFreezeRotation;
    }
}
