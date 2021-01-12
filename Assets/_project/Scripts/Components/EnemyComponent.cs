using Unity.Entities;
using Unity.Mathematics;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct EnemyComponent : IComponentData
    {
        public float3 PreviousCell;
    }

}
