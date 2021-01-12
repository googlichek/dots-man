using Game.Scripts;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

public class MovableSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;
        Entities
            .ForEach((ref PhysicsVelocity velocity, in MovableComponent movable) =>
            {
                var step = movable.Speed * movable.Direction;
                velocity.Linear = step;
            })
            .Schedule();
    }
}
