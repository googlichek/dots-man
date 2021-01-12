using Game.Scripts;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

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
    }
}
