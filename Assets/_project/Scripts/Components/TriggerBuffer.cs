using Unity.Entities;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct TriggerBuffer : IBufferElementData
    {
        public Entity Entity;
    }
}
