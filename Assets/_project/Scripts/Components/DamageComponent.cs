using Unity.Entities;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct DamageComponent : IComponentData
    {
        public float Value;
    }
}
