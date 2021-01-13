using Unity.Entities;

namespace Game.Scripts
{
    public class DamageSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;

            Entities
                .ForEach((DynamicBuffer<CollisionBuffer> collisionBuffer, ref HealthComponent health) =>
                {
                    for (int i = 0; i < collisionBuffer.Length; i++)
                    {
                        if (health.InvincibleTimer <= 0 && HasComponent<DamageComponent>(collisionBuffer[i].Entity))
                        {
                            health.Value -= GetComponent<DamageComponent>(collisionBuffer[i].Entity).Value;
                            health.InvincibleTimer = 1;
                        }
                    }
                })
                .Schedule();

            Entities
                .WithNone<KillComponent>()
                .ForEach((Entity entity, ref HealthComponent health) =>
                {
                    health.InvincibleTimer -= deltaTime;

                    if (health.Value <= 0)
                        EntityManager.AddComponentData(entity, new KillComponent { Timer = health.KillTimer });

                })
                .WithStructuralChanges()
                .Run();

            var entityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
            var entityCommandBuffer = entityCommandBufferSystem.CreateCommandBuffer();

            Entities
                .ForEach((Entity entity, int entityInQueryIndex, ref KillComponent kill) =>
                {
                    kill.Timer -= deltaTime;

                    if (kill.Timer <= 0)
                        entityCommandBuffer.DestroyEntity(entity);
                })
                .WithoutBurst()
                .Run();

            entityCommandBufferSystem.AddJobHandleForProducer(Dependency);
        }
    }
}
