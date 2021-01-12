using Unity.Entities;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct HealthComponent : IComponentData
    {
        public float Value;
        public float InvincibleTimer;
        public float KillTimer;
    }
}
