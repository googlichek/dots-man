using Unity.Collections;
using Unity.Entities;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct OnKillComponent : IComponentData
    {
        public FixedString64 SFXName;
        public Entity SpawnPrefab;
        public int PointValue;
    }
}
