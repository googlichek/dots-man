
using Unity.Entities;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct SpawnerComponent : IComponentData
    {
        public Entity SpawnPrefab;
        public Entity SpawnObject;
    }
}
