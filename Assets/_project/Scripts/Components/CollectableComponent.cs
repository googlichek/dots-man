using Unity.Entities;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct CollectableComponent : IComponentData
    {
        public float Points;
    }
}
