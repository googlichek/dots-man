using Unity.Entities;

namespace Game.Scripts
{
    [GenerateAuthoringComponent]
    public struct PowerPillComponent : IComponentData
    {
        public float PillTimer;
    }
}
