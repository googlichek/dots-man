using Unity.Entities;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct CollisionBuffer : IBufferElementData
    {
        public Entity Entity;
    }
}
