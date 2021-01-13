using Unity.Entities;

namespace Game.Scripts
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class CollectionSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var entityCommandBuffer = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>().CreateCommandBuffer();

            Entities
                .WithAll<PlayerComponent>()
                .ForEach((Entity playerEntity, DynamicBuffer<TriggerBuffer> triggerBuffer) =>
                {
                    for (int i = 0; i < triggerBuffer.Length; i++)
                    {
                        var entity = triggerBuffer[i].Entity;

                        if (HasComponent<CollectableComponent>(entity) && !HasComponent<KillComponent>(entity))
                        {
                            entityCommandBuffer.AddComponent(entity, new KillComponent() { Timer = 0 });
                        }

                        if (HasComponent<PowerPillComponent>(entity) && !HasComponent<KillComponent>(entity))
                        {
                            entityCommandBuffer.AddComponent(playerEntity, GetComponent<PowerPillComponent>(entity));
                            entityCommandBuffer.AddComponent(entity, new KillComponent() { Timer = 0 });
                        }
                    }
                })
                .WithStructuralChanges()
                .Run();
        }
    }
}
