using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts
{
    public class PlayerSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            var deltaTime = Time.DeltaTime;

            Entities
                .WithAll<PlayerComponent>()
                .ForEach((ref MovableComponent movable) => { movable.Direction = new float3(x, 0, z); })
                .Schedule();

            var entityCommandBuffer = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>().CreateCommandBuffer();

            Entities
                .WithAll<PlayerComponent>()
                .ForEach((Entity entity, ref HealthComponent health, ref PowerPillComponent powerPill, ref DamageComponent damage) =>
                    {
                        damage.Value = 100;

                        powerPill.PillTimer -= deltaTime;
                        health.InvincibleTimer = powerPill.PillTimer;

                        if (powerPill.PillTimer <= 0)
                        {
                            entityCommandBuffer.RemoveComponent<PowerPillComponent>(entity);
                            damage.Value = 0;
                        }
                    })
                .Schedule();
        }
    }
}
