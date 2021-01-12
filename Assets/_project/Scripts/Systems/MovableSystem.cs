using Game.Scripts;
using Unity.Entities;
using Unity.Transforms;

public class MovableSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;
        Entities
            .ForEach((ref MovableComponent movable, ref Translation translation, ref Rotation rotation) =>
                {
                    translation.Value += movable.Speed * movable.Direction * deltaTime;
                })
            .Schedule();
    }
}
